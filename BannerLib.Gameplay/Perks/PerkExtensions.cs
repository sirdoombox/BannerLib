using TaleWorlds.CampaignSystem;

namespace BannerLib.Gameplay.Perks
{
#pragma warning disable 1591
    public static class PerkBaseExtensions
#pragma warning restore 1591
    {
        /// <summary>
        /// Checks if a perk is present on a hero.
        /// </summary>
        /// <param name="perk">The perk to check.</param>
        /// <param name="hero">The hero to check.</param>
        /// <returns>True if it is present, false if it is not.</returns>
        public static bool PerkPresentOnHero(this PerkBase perk, Hero hero) =>
            hero.GetPerkValue(perk);
    }
}