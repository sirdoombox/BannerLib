using System;
using BannerLib.Gameplay.Perks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
#pragma warning disable 1591

namespace BannerLib.Gameplay
{
    public class GameplaySubModule : MBSubModuleBase
    {
        // STUB: Used purely to get the submodules to load correctly. (For Now)
        public override void OnGameInitializationFinished(Game game)
        {
            if (!(game.GameType is Campaign)) return;
            var perkBuilder = PerkBuilder.Create(game, "TestMod", DefaultSkills.Trade, 0);
            perkBuilder.CreatePerk("testLeaderShipGoldIncrease", "Investment Banking", "Increases Total Gold By 20% Per Hour")
                .WithPrimaryRole(SkillEffect.PerkRole.ArmyCommander)
                .WithPrimaryBonus(20)
                .WithEffectType(SkillEffect.EffectIncrementType.AddFactor);
            perkBuilder.CreateAlternativePerk("testLeaderShipGoldReduction", "Bad Investment Banking", "Reduces Total Gold By 20% Per Hour")
                .WithPrimaryRole(SkillEffect.PerkRole.ArmyCommander)
                .WithPrimaryBonus(-20)
                .WithEffectType(SkillEffect.EffectIncrementType.AddFactor);
            var builtPerks = perkBuilder.Build();
            CampaignEvents.HourlyTickEvent.AddNonSerializedListener(this, () => { 
                foreach(var hero in Hero.All)
                {
                    var result = builtPerks.BuiltPerkPresentOnHero(hero);
                    if (!result.isEitherPerkPresent) continue;
                    hero.ChangeHeroGold((int) Math.Round(hero.Gold * (result.presentPerk.PrimaryBonus * 0.01f)));
                }
            });

            var existingBuilder = PerkBuilder.CreateFromExisting(game, "TestMod", DefaultPerks.Scouting.Navigator);
            existingBuilder.CreateAlternativePerk("TestForaging", "Foraging", "Forage for food or whatever.")
                .WithPrimaryRole(SkillEffect.PerkRole.Scout)
                .WithPrimaryBonus(20)
                .WithEffectType(SkillEffect.EffectIncrementType.AddFactor);
            var builtExisting = existingBuilder.Build();
        }
    }
}