using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Configuration
{
    public class EventBusSettings
    {
        public bool AzureServiceBusEnabled { get; set; }
        public string SubscriptionClientName { get; set; }
        public int CheckUpdateTime { get; set; }
        public string EventBusRetryCount { get; set; }
        public string EventBusConnection { get; set; }
        public string EventBusUsername { get; set; }
        public string EventBusPassword { get; set; }
    }
}
