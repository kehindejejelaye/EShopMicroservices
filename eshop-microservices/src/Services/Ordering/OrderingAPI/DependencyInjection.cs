﻿namespace OrderingAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            return services;
        }

        //public static async WebApplication UseApiServices(this WebApplication app)
        //{
        //    // app.MapCarter();
            
        //    return app;
        //}
    }
}
