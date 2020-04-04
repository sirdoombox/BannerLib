using TaleWorlds.CampaignSystem;

namespace BannerLib.Gameplay.Perks
{
#pragma warning disable 1591
    public static class PerkExtensions
#pragma warning restore 1591
    {
        /// <summary>
        /// Checks if a perk is present on a hero.
        /// </summary>
        /// <param name="perk">The perk to check.</param>
        /// <param name="hero">The hero to check.</param>
        /// <returns>True if it is present, false if it is not.</returns>
        public static bool PerkPresentOnHero(this Perk perk, Hero hero) =>
            hero.GetPerkValue(perk);

        /// <summary>
        /// Checks if a given hero has either the primary or alternative perks returned by the PerkBuilder.Build() Method.
        /// </summary>
        /// <param name="builtPerks">Perk Tuple (Returned by PerkBuilder.Build())</param>
        /// <param name="hero">Hero to check for perks.</param>
        /// <returns>One of either perks if it is present, null if neither are present.</returns>
        public static Perk BuiltPerkPresentOnHero(this (Perk, Perk) builtPerks, Hero hero)
        {
            if (builtPerks.Item1.PerkPresentOnHero(hero)) return builtPerks.Item1;
            return builtPerks.Item2.PerkPresentOnHero(hero) ? builtPerks.Item2 : null;
        }
    }
}