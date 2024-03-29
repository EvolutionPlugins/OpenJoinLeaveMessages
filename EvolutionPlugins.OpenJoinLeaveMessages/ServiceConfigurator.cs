﻿using EvolutionPlugins.Universal.Extras.Broadcast;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenMod.API.Ioc;

namespace EvolutionPlugins.OpenJoinLeaveMessages
{
    public class ServiceConfigurator : IServiceConfigurator
    {
        public void ConfigureServices(IOpenModServiceConfigurationContext openModStartupContext, IServiceCollection serviceCollection)
        {
            serviceCollection.Configure<BroadcastManagerOptions>(x =>
            {
                x.AddBroadcastProvider<DefaultBroadcastProvider>();
            });
            serviceCollection.TryAddSingleton<IBroadcastManager, BroadcastManager>();
        }
    }
}
