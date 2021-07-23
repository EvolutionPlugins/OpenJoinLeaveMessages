using EvolutionPlugins.OpenJoinLeaveMessages.Extensions;
using EvolutionPlugins.Universal.Extras.Broadcast;
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
        private readonly ILogger<UserConnectedEvent> m_Logger;
        private readonly IBroadcastManager m_BroadcastManager;

        public UserConnectedEvent(IStringLocalizer stringLocalizer, IConfiguration configuration,
            ILogger<UserConnectedEvent> logger, IBroadcastManager broadcastManager)
        {
            m_StringLocalizer = stringLocalizer;
            m_Configuration = configuration;
            m_Logger = logger;
            m_BroadcastManager = broadcastManager;
        }

        public Task HandleEventAsync(object? sender, IUserConnectedEvent @event)
        {
            var color = m_Configuration["colors:join"].ParseColor(Color.White);

            m_Logger.LogDebug($"Parsed color: {color}");

            return m_BroadcastManager.BroadcastAsync(m_StringLocalizer["join", new { @event.User }],
                m_Configuration["iconUrls:join"], color);
        }
    }
}
