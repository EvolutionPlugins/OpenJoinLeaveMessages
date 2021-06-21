using Microsoft.Extensions.Logging;
using OpenMod.API.Plugins;
using OpenMod.Core.Plugins;
using System;
using System.Threading.Tasks;

[assembly: PluginMetadata("EvolutionPlugins.OpenJoinLeaveMessages", Author = "EvolutionPlugins", DisplayName = "Open Join & Leave Messages",
    Website = "https://discord.gg/5MT2yke")]

namespace EvolutionPlugins.OpenJoinLeaveMessages
{
    public class OpenJoinLeaveMessages : OpenModUniversalPlugin
    {
        private readonly ILogger<OpenJoinLeaveMessages> m_Logger;

        public OpenJoinLeaveMessages(IServiceProvider serviceProvider, ILogger<OpenJoinLeaveMessages> logger) : base(serviceProvider)
        {
            m_Logger = logger;
        }

        protected override Task OnLoadAsync()
        {
            m_Logger.LogInformation("Made with <3 by Evolution Plugins");
            m_Logger.LogInformation("Owner of EvolutionPlugins: DiFFoZ");
            m_Logger.LogInformation("https://github.com/evolutionplugins \\ https://github.com/diffoz");
            m_Logger.LogInformation("Discord Support: https://discord.gg/6KymqGv");

            return Task.CompletedTask;
        }
    }
}
