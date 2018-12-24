namespace Microsoft.Extensions.HealthChecks
{
    using System.Collections.Generic;

    public class HealthCheckResults
    {
        public IList<IHealthCheckResult> CheckResults { get; } = new List<IHealthCheckResult>();
    }
}
