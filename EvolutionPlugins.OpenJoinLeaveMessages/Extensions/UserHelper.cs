namespace EvolutionPlugins.OpenJoinLeaveMessages.Extensions
{
    internal static class UserHelper
    {
        /// <summary>
        /// Ignores AI users (<see href="https://github.com/EvolutionPlugins/Dummy"/>)
        /// </summary>
        public static bool ShouldIgnoreUserId(string userId)
        {
            return ulong.TryParse(userId, out var id)
                    && (id < 76561197960265728 || id > 76561202255233023);
        }
    }
}
