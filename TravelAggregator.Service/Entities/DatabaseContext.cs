using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAggregator.Service.Constants;

namespace TravelAggregator.Service.Entities;

public class DatabaseContext : DbContext
{
    public DatabaseContext() { }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public virtual DbSet<Reservation> Reservations { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.Status)
                    .HasConversion(
                        s => s.ToString(),
                        s => (ReservationStatus)Enum.Parse(typeof(ReservationStatus), s));

                entity.Property(e => e.Id)
                    .HasConversion(new GuidToStringConverter());

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
    }

}
