using EvolutionPlugins.Universal.Extras;
using EvolutionPlugins.Universal.Extras.Broadcast;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenMod.API.Ioc;
using OpenMod.API.Prioritization;

namespace EvolutionPlugins.OpenJoinLeaveMessages
{
    public class ServiceConfigurator : IServiceConfigurator
    {
        public void ConfigureServices(IOpenModServiceConfigurationContext openModStartupContext, IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton<IBroadcastManager, BroadcastManager>();
        }
    }
}
