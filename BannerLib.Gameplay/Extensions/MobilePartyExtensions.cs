using System;
using TaleWorlds.CampaignSystem;

namespace BannerLib.Gameplay.Extensions
{
#pragma warning disable 1591
    public static class MobilePartyExtensions
#pragma warning restore 1591
    {
        private const string c_SPEED_CHECK_VERSION_FIELD = "_partyPureSpeedLastCheckVersion";
        private const int c_SPEED_CHECK_VALUE = -1;
        
        /// <summary>
        /// Overrides internal MobileParty speed caching and forces compute to apply.
        /// Calling ComputeSpeed doesn't cause the speed to update due to caching.
        /// </summary>
        /// <param name="mobileParty">Mobile Party object to apply speed computation to.</param>
        /// <exception cref="ArgumentNullException">Thrown when the mobileParty is null.</exception>
        public static void ForceComputeSpeed(this MobileParty mobileParty)
        {
            if(mobileParty is null) 
                throw new ArgumentNullException(nameof(mobileParty), $"{nameof(mobileParty)} cannot be null.");
            var speedField = typeof(MobileParty).GetField(c_SPEED_CHECK_VERSION_FIELD, 
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            speedField?.SetValue(mobileParty, c_SPEED_CHECK_VALUE);
            mobileParty.ComputeSpeed();
        }
    }
}