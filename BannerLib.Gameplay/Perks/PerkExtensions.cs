using TaleWorlds.CampaignSystem;

namespace BannerLib.Gameplay.Perks
{
    public static class PerkExtensions
    {
        public static bool PerkPresentOnHero(this Perk perk, Hero hero) =>
            hero.GetPerkValue(perk);

        public static (bool isEitherPerkPresent, Perk presentPerk) BuiltPerkPresentOnHero(this (Perk, Perk) builtPerks, Hero hero)
        {
            if (builtPerks.Item1.PerkPresentOnHero(hero)) return (true, builtPerks.Item1);
            if (builtPerks.Item2.PerkPresentOnHero(hero)) return (true, builtPerks.Item2);
            return (false, null);
        }
    }
}