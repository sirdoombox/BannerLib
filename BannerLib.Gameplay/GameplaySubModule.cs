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
            if (!(game.GameType is Campaign)) return ;
            var perks = new PerkCreator(game, "TestMod");
            var test = Campaign.Current.PerkList.Where(x => x.StringId.Contains("TestMod"));
            perks.RegisterAlternatives<TestingPerk, TestingAlternate>();
            perks.UpdatePerks();
            var stringAss = "ass";
            // var perkBuilder = PerkBuilder.Create(game, "TestMod", DefaultSkills.Trade, 0);
            // var newPerk = perkBuilder.CreatePerk("testLeaderShipGoldIncrease", "Investment Banking", "Increases Total Gold By 1% Per Hour");
            // if (perkBuilder.PerkAlreadyExists)
            // {
            //     newPerk.WithPrimaryRole(SkillEffect.PerkRole.ArmyCommander)
            //         .WithPrimaryBonus(1)
            //         .WithEffectType(SkillEffect.EffectIncrementType.AddFactor);
            // }
            //
            // var alternatePerk = perkBuilder.CreateAlternativePerk("testLeaderShipGoldReduction", "Bad Investment Banking", "Reduces Total Gold By 1% Per Hour");
            // if(perkBuilder.AlternatePerkAlreadyExists)
            //     .WithPrimaryRole(SkillEffect.PerkRole.ArmyCommander)
            //     .WithPrimaryBonus(-1)
            //     .WithEffectType(SkillEffect.EffectIncrementType.AddFactor);
            // var builtPerks = perkBuilder.Build();
            // CampaignEvents.HourlyTickEvent.AddNonSerializedListener(this, () => { 
            //     foreach(var hero in Hero.All)
            //     {
            //         var presentPerk = builtPerks.BuiltPerkPresentOnHero(hero);
            //         if (presentPerk is null) continue;
            //         hero.ChangeHeroGold((int) Math.Round(hero.Gold * (presentPerk.PrimaryBonus * 0.01f)));
            //     }
            // });
            //
            // var existingBuilder = PerkBuilder.CreateFromExisting(game, "TestMod", DefaultPerks.Scouting.Navigator);
            // existingBuilder.CreateAlternativePerk("TestForaging", "Foraging", "Forage for food or whatever.")
            //     .WithPrimaryRole(SkillEffect.PerkRole.Scout)
            //     .WithPrimaryBonus(20)
            //     .WithEffectType(SkillEffect.EffectIncrementType.AddFactor);
            // var builtExisting = existingBuilder.Build();
        }

        protected override void OnApplicationTick(float dt)
        {
            if (Campaign.Current is null) return;
            var test = Campaign.Current.PerkList.Where(x => x.StringId.Contains("TestMod"));
            var stringAss = "ass";
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