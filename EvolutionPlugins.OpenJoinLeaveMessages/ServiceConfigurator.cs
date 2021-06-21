using EvolutionPlugins.Universal.Extras;
using Microsoft.Extensions.DependencyInjection;
using OpenMod.API.Ioc;

namespace EvolutionPlugins.OpenJoinLeaveMessages
{
    public class ServiceConfigurator : IServiceConfigurator
    {
        public void ConfigureServices(IOpenModServiceConfigurationContext openModStartupContext, IServiceCollection serviceCollection)
        {
            serviceCollection.AddBroadcastManager();
        }
    }
}
