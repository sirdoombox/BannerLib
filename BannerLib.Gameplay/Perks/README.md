# Perks

Allows easily adding perks to a game with their existence and state being saved automatically as part of the save system, running the code on a game which has already had these perks saved will simply load them back up instead of registering them _"as new"_.

## Example Usage

```csharp
public class ExampleSubModule : MBSubModuleBase
    {
    	// Run this once the game has finished initialization.
        public override void OnGameInitializationFinished(Game game)
        {
            // Only run this if we're in the campaign.
            if (!(game.GameType is Campaign)) return ;
            // Initialize a PerkCreator for your mod.
            var perks = new PerkCreator(game, "TestMod");
            // Register two perks which are treated as alternatives.
            perks.RegisterAlternatives<TestingPerk, TestingAlternate>();
            // Call this once you're done adding perks.
            perks.UpdatePerks();
        }
    }

	
	// Creating a perk type is as easy as this, derive from perkbase and in the constructor
	// Set all the properties you need.
	// You can freely add extra functionality to your perk for your own use.
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
```

