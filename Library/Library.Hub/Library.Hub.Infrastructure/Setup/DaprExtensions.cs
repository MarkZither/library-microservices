﻿using Library.Hub.Infrastructure.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Library.Hub.Infrastructure.Handlers;
using Library.Hub.Core.Interfaces;

namespace Library.Hub.Infrastructure.Setup
{
    public static class DaprExtensions
    {
        public static IServiceCollection AddDaprService(this IServiceCollection services)
        {
            services.AddDaprClient();

            services.AddSingleton<IDaprHandler, DaprHandler>();
            services.AddSingleton<IMessageEventStore<MessageEvent>, MessageEventStore>();

            return services;
        }

        public static IMvcBuilder AddDaprForMvc(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder.AddDapr();

            return mvcBuilder;
        }

        public static IApplicationBuilder UseDaprServices(this IApplicationBuilder app)
        {
            app.UseCloudEvents();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapSubscribeHandler();
            });

            return app;
        }
    }
}
