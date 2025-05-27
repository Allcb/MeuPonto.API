using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MeuPonto.Infra.CrossCutting.HealthChecks.Providers
{
    public class CustomHealthChecks : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken
        cancellationToken = default)
        {
            var healthCheckResultHealthy = true;

            if (healthCheckResultHealthy)
            {
                return Task.FromResult(HealthCheckResult.Healthy("API está saudável"));
            }

            return Task.FromResult(new HealthCheckResult(status: HealthStatus.Unhealthy,
                                                         description: "API com problemas"));
        }
    }
}