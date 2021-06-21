using OpenMod.API.Plugins;
using OpenMod.Core.Plugins;
using System;

[assembly: PluginMetadata("EvolutionPlugins.OpenJoinLeaveMessages", Author = "EvolutionPlugins", DisplayName = "Open Join & Leave Messages",
    Website = "https://discord.gg/5MT2yke")]

namespace EvolutionPlugins.OpenJoinLeaveMessages
{
    public class OpenJoinLeaveMessages : OpenModUniversalPlugin
    {
        public OpenJoinLeaveMessages(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
