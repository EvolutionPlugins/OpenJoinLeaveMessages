using EvolutionPlugins.OpenJoinLeaveMessages.Extensions;
using EvolutionPlugins.Universal.Extras.Broadcast;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OpenMod.API.Eventing;
using OpenMod.Core.Eventing;
using OpenMod.Core.Users.Events;
using System.Drawing;
using System.Threading.Tasks;

namespace EvolutionPlugins.OpenJoinLeaveMessages.Events
{
    public class UserFirstConnectingEvent : IEventListener<IUserFirstConnectingEvent>
    {
        private readonly IStringLocalizer m_StringLocalizer;
        private readonly IConfiguration m_Configuration;
        private readonly ILogger<UserDisconnectedEvent> m_Logger;
        private readonly IBroadcastManager m_BroadcastManager;

        public UserFirstConnectingEvent(IStringLocalizer stringLocalizer, IConfiguration configuration,
            ILogger<UserDisconnectedEvent> logger, IBroadcastManager broadcastManager)
        {
            m_StringLocalizer = stringLocalizer;
            m_Configuration = configuration;
            m_Logger = logger;
            m_BroadcastManager = broadcastManager;
        }

        [EventListener(Priority = EventListenerPriority.Monitor)]
        public Task HandleEventAsync(object? sender, IUserFirstConnectingEvent @event)
        {
            if (UserHelper.ShouldIgnoreUserId(@event.User.Id))
                return Task.CompletedTask;

            var color = m_Configuration["colors:firstJoin"].ParseColor(Color.White);

            m_Logger.LogDebug($"Parsed color: {color}");

            return m_BroadcastManager.BroadcastAsync(m_StringLocalizer["firstJoin", new { @event.User }],
                m_Configuration["iconUrls:firstJoin"], color);
        }
    }
}
