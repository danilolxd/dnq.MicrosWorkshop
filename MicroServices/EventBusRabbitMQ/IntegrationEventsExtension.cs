using Autofac;
using EventBus;
using EventBus.Abstractions;
using EventBus.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace EventBusRabbitMQ
{
    public static class IntegrationEventsExtension
    {
        public static IServiceCollection AddRabbitMQIntegrationEvents(this IServiceCollection services, EventBusSettings settings)
        {
            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = 5;
                if (!string.IsNullOrEmpty(settings.EventBusRetryCount))
                {
                    retryCount = int.Parse(settings.EventBusRetryCount);
                }

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope,
                    eventBusSubcriptionsManager, settings.SubscriptionClientName, retryCount);
            });

            services.AddSingleton((System.Func<System.IServiceProvider, IRabbitMQPersistentConnection>)(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();


                var factory = new ConnectionFactory()
                {
                    HostName = settings.EventBusConnection
                };

                if (!string.IsNullOrEmpty(settings.EventBusUsername))
                {
                    factory.UserName = settings.EventBusUsername;
                }

                if (!string.IsNullOrEmpty(settings.EventBusPassword))
                {
                    factory.Password = settings.EventBusPassword;
                }

                var retryCount = 5;
                if (!string.IsNullOrEmpty(settings.EventBusRetryCount))
                {
                    retryCount = int.Parse(settings.EventBusRetryCount);
                }

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            }));

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

            return services;
        }
    }
}