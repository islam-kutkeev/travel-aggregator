using AspNetCore.Authentication.Basic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TravelAggregator.Service.Configurations;
using TravelAggregator.Service.Entities;
using TravelAggregator.Service.Repositories.ReservationRepository;
using TravelAggregator.Service.Services;
using TravelAggregator.Service.Services.TicketSourceService;

var builder = WebApplication.CreateBuilder(args);

// Setup logger
builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.WithProperty("Environment", builder.Environment.EnvironmentName);
});

// Auth
builder.Services.AddAuthentication(BasicDefaults.AuthenticationScheme)
    .AddBasic<BasicUserValidationService>(options => { options.Realm = "TravelAggregator"; });

// Add EF Core
builder.Services.AddDbContext<DatabaseContext>(options => options
    .UseNpgsql(builder.Configuration.GetConnectionString("Default")));

// Mapper
builder.Services.AddAutoMapper(typeof(TicketSourceProfile));

// Add Caching
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

// Add services to the container.
builder.Services.AddHttpClient();

builder.Services.AddTransient<ITicketSourceService, MyAirlinesService>();
builder.Services.AddTransient<ITicketSourceService, AviaTalesService>();
builder.Services.AddTransient<IReservationRepository, ReservationRepository>();
builder.Services.AddTransient<AggregatorService>();
builder.Services.AddTransient<HttpInteractionService>();
builder.Services.AddTransient<CacheService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseAuthentication();

app.Run();