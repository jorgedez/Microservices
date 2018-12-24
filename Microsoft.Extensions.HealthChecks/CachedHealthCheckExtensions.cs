namespace Microsoft.Extensions.HealthChecks
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public static class CachedHealthCheckExtensions
    {
        public static ValueTask<IHealthCheckResult> RunAsync(this CachedHealthCheck check, IServiceProvider serviceProvider)
        {
            Guard.ArgumentNotNull(nameof(check), check);

            return check.RunAsync(serviceProvider, CancellationToken.None);
        }
    }
}
