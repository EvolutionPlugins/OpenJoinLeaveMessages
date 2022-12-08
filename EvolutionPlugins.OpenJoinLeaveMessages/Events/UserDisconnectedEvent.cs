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
    public class UserDisconnectedEvent : IEventListener<IUserDisconnectedEvent>
    {
        private readonly IStringLocalizer m_StringLocalizer;
        private readonly IConfiguration m_Configuration;
        private readonly ILogger<UserDisconnectedEvent> m_Logger;
        private readonly IBroadcastManager m_BroadcastManager;

        public UserDisconnectedEvent(IStringLocalizer stringLocalizer, IConfiguration configuration,
            ILogger<UserDisconnectedEvent> logger, IBroadcastManager broadcastManager)
        {
            m_StringLocalizer = stringLocalizer;
            m_Configuration = configuration;
            m_Logger = logger;
            m_BroadcastManager = broadcastManager;
        }

        public Task HandleEventAsync(object? sender, IUserDisconnectedEvent @event)
        {
            if (UserHelper.ShouldIgnoreUserId(@event.User.Id))
                return Task.CompletedTask;

            var color = m_Configuration["colors:leave"].ParseColor(Color.White);

            m_Logger.LogDebug($"Parsed color: {color}");

            return m_BroadcastManager.BroadcastAsync(m_StringLocalizer["leave", new { @event.User }],
                m_Configuration["iconUrls:leave"], color);
        }
    }
}
