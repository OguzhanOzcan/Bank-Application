using Prometheus;

namespace ServerApp.Helpers
{
    public static class MetricsRegistry
    {
        public static readonly Counter CreditApplications = Metrics.CreateCounter(
            "credit_applications_total",
            "Kredi başvurusu sayısı statü bazında",
            new CounterConfiguration
            {
                LabelNames = new[] { "status" }
            }
        );

        public static readonly Counter Exceptions = Metrics.CreateCounter(
            "exceptions_total",
            "Yakalanan global hata sayısı",
            new CounterConfiguration
            {
                LabelNames = new[] { "type" }
            }
        );
        
        public static readonly Histogram ApiResponseTime = Metrics.CreateHistogram(
            "api_response_time_seconds",
            "API yanıt süresi saniye cinsinden",
            new HistogramConfiguration{
                LabelNames = new[] { "method", "endpoint", "status_code" }
            }
        );
    }
}
