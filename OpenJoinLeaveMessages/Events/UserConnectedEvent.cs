using EvolutionPlugins.OpenJoinLeaveMessages.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OpenMod.API.Eventing;
using OpenMod.Core.Users.Events;
using System.Drawing;
using System.Threading.Tasks;

namespace EvolutionPlugins.OpenJoinLeaveMessages.Events
{
    public class UserConnectedEvent : IEventListener<IUserConnectedEvent>
    {
        private readonly IStringLocalizer m_StringLocalizer;
        private readonly IConfiguration m_Configuration;
        private readonly ILogger<OpenJoinLeaveMessages> m_Logger;

        public UserConnectedEvent(IStringLocalizer stringLocalizer, IConfiguration configuration, ILogger<OpenJoinLeaveMessages> logger)
        {
            m_StringLocalizer = stringLocalizer;
            m_Configuration = configuration;
            m_Logger = logger;
        }

        public Task HandleEventAsync(object? sender, IUserConnectedEvent @event)
        {
            var color = m_Configuration["colors:join"].ParseColor(Color.White);

            m_Logger.LogDebug($"[Join Event] Parsed color: {color}");

            var provider = @event.User.Provider;
            if (provider != null)
            {
                return provider.BroadcastAsync(m_StringLocalizer["join", new { @event.User }], color);
            }

            return Task.CompletedTask;
        }
    }
}
