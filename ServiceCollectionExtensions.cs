using System;
using Microsoft.Extensions.DependencyInjection;
using ProxyPayApiClient.Core.Interfaces;
using ProxyPayApiClient.Infrastructure.Services;

namespace ProxyPayApiClient.Library
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProxyPayApiClient(this IServiceCollection services, string baseUrl, string accessToken)
        {
            services.AddHttpClient<IProxyPayService, ProxyPayService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            });

            return services;
        }
    }
}
