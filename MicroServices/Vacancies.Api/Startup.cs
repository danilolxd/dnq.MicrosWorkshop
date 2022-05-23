using Autofac;
using Common.Infrastructure;
using EventBus.Abstractions;
using EventBusRabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using Vacancies.Application.Configuration;
using Vacancies.Application.IntegrationEvents;
using Vacancies.Domain.Entities;
using Vacancies.Infrastructure.Contexts;

namespace Vacancies.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration);

            var settings = Configuration.Get<AppSettings>();

            services.AddOptions().AddControllers().AddControllersAsServices();

            services.AddEntityFrameworkSqlServer()
                    .AddDbContext<VacancyContext>(opts => opts.UseSqlServer(settings.ConnectionStrings.DefaultConnection,
                        sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(VacancyContext).GetTypeInfo().Assembly.GetName().Name);
                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: null);
                        }), ServiceLifetime.Scoped);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Vacancies API v1", Version = "v1" });
            });

            services.AddRabbitMQIntegrationEvents(settings.EventBus);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Startup).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(AppSettings).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(Vacancy).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(VacancyContext).Assembly).AsImplementedInterfaces();

            builder.RegisterMediatR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vacancies API v1");
                   c.RoutePrefix = string.Empty;
               });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<CandidateAddedIntegrationEvent, IIntegrationEventHandler<CandidateAddedIntegrationEvent>>();
        }
    }
}
