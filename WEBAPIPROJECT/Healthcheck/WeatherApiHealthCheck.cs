using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WEBAPIPROJECT.Healthcheck
{
    public class WeatherApiHealthCheck:IHealthCheck
    {
        public readonly HttpClient _httpClient;
        public readonly string webapiurl = "http://localhost:5054/WeatherForecast";
        public WeatherApiHealthCheck(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {

            var response = await _httpClient.GetAsync(webapiurl, cancellationToken);
             
            if(response.IsSuccessStatusCode)
            {
                return HealthCheckResult.Healthy("API IS HEALTHY");

            }
            else
            {
                return HealthCheckResult.Unhealthy("API IS UNHEALTHY");
            }
        }
    }
}
