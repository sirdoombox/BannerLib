using System;
using System.Linq;
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
            // TEST: Just trying to figure out why this is broken.
            if (!(game.GameType is Campaign)) return ;
            var perks = new PerkCreator(game, "TestMod");
            perks.RegisterAlternatives<TestingPerk, TestingAlternate>();
            perks.UpdatePerks();
        }
    }


    public class TestingPerk : PerkBase
    {
        public TestingPerk()
        {
            Name = "Testing Perk One";
            PrimaryBonus = 10;
            Description = $"Deal {PrimaryBonus} Extra Damage.";
            PrimaryRole = SkillEffect.PerkRole.PartyMember;
            EffectType = SkillEffect.EffectIncrementType.Add;
            Skill = DefaultSkills.Bow;
            PerkSkillRequirement = 0;
        }
    }
    
    public class TestingAlternate : PerkBase
    {
        public TestingAlternate()
        {
            Name = "Testing Perk Two";
            PrimaryBonus = 100;
            Description = $"Deal {PrimaryBonus} Less Damage.";
            PrimaryRole = SkillEffect.PerkRole.PartyMember;
            EffectType = SkillEffect.EffectIncrementType.Add;
            Skill = DefaultSkills.Bow;
            PerkSkillRequirement = 0;
        }
    }
}