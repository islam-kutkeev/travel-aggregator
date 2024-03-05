using AspNetCore.Authentication.Basic;

namespace TravelAggregator.Service.Services;

public class BasicUserValidationService : IBasicUserValidationService
{
    private readonly ILogger<BasicUserValidationService> _logger;
    private readonly IConfiguration _configuration;

    public BasicUserValidationService(ILogger<BasicUserValidationService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _username = configuration["Auth:Username"];
        _password = configuration["Auth:Password"];
    }

    private string _username;
    private string _password;

    /// <summary>
    /// !!! SIMPLIFIED !!!
    /// DO NOT USE FOR PRODUCTION
    /// </summary>
    public async Task<bool> IsValidAsync(string username, string password)
    {
        try
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            return _username.Equals(username) && _password.Equals(password);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
}
