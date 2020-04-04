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
            var perkBuilder = PerkBuilder.Create(game, "TestMod", DefaultSkills.Leadership, 37);
            perkBuilder.CreatePerk("testLeaderShipGoldReduction", "Payroll", "Reduce wages by 5%")
                .WithPrimaryRole(SkillEffect.PerkRole.ArmyCommander)
                .WithPrimaryBonus(-0.05f)
                .WithAddFactorIncrementType();
            perkBuilder.CreateAlternativePerk("testLeaderShipFoodReduction", "Head Chef", "Reduce food usage by 5%")
                .WithPrimaryRole(SkillEffect.PerkRole.ArmyCommander)
                .WithPrimaryBonus(-0.05f)
                .WithAddFactorIncrementType();
            perkBuilder.Build();
        }
    }
}