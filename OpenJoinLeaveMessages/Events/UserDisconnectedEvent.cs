using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OpenJoinLeaveMessages.Extensions;
using OpenMod.API.Eventing;
using OpenMod.Core.Users.Events;
using System.Drawing;
using System.Threading.Tasks;

namespace OpenJoinLeaveMessages.Events
{
    public class UserDisconnectedEvent : IEventListener<IUserDisconnectedEvent>
    {
        private readonly IStringLocalizer m_StringLocalizer;
        private readonly IConfiguration m_Configuration;
        private readonly ILogger<OpenJoinLeaveMessages> m_Logger;

        public UserDisconnectedEvent(IStringLocalizer stringLocalizer, IConfiguration configuration, ILogger<OpenJoinLeaveMessages> logger)
        {
            m_StringLocalizer = stringLocalizer;
            m_Configuration = configuration;
            m_Logger = logger;
        }

        public Task HandleEventAsync(object? sender, IUserDisconnectedEvent @event)
        {
            var color = m_Configuration["colors:leave"].ParseColor(Color.White);

            m_Logger.LogDebug($"[Leave Event] Parsed color: {color}");

            var provider = @event.User.Provider;
            if (provider != null)
            {
                return provider.BroadcastAsync(m_StringLocalizer["leave", new { @event.User }], color);
            }

            return Task.CompletedTask;
        }
    }
}
