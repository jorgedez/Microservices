namespace Microsoft.Extensions.HealthChecks
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IHealthCheck
    {
        ValueTask<IHealthCheckResult> CheckAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
