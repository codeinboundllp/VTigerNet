using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VtigerIntegration.Interfaces;
using VtigerIntegration.Models;
using VtigerIntegration.Service;

namespace VtigerIntegration
{
    public static class Configuration
    {
        public static  IServiceCollection AddVTigerService(this IServiceCollection services, IConfiguration configuration)
        {
            var VTigerConfiguration = new VTigerConfiguration();
            configuration.Bind("CRMConfiguration:" + nameof(VTigerConfiguration), VTigerConfiguration);
            services.AddSingleton<IVTigerService>(new VTigerAPIService(VTigerConfiguration));
            return services;
        }
    }
}
