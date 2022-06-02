using EventBus.Configuration;

namespace Candidates.Application.Configuration
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }

        public EventBusSettings EventBus { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }
}