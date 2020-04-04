using TaleWorlds.CampaignSystem;

namespace BannerLib.Gameplay.Perks
{
    public class Perk
    {
        internal string Name { get; }
        internal string Description { get; }
        internal float PrimaryBonus { get; private set; }
        internal SkillEffect.PerkRole PrimaryRole { get; private set; }
        internal float SecondaryBonus { get; private set; }
        internal SkillEffect.PerkRole SecondaryRole { get; private set; }
        internal SkillEffect.EffectIncrementType IncrementType { get; private set; }

        internal Perk(string name, string description)
        {
            Name = name;
            Description = description;
            PrimaryBonus = 0;
            PrimaryRole = SkillEffect.PerkRole.None;
            SecondaryRole = SkillEffect.PerkRole.None;
            SecondaryBonus = 0;
            IncrementType = SkillEffect.EffectIncrementType.Add;
        }

        public Perk WithPrimaryBonus(float bonus)
        {
            PrimaryBonus = bonus;
            return this;
        }

        public Perk WithPrimaryRole(SkillEffect.PerkRole role)
        {
            PrimaryRole = role;
            return this;
        }

        public Perk WithSecondaryBonus(float bonus)
        {
            SecondaryBonus = bonus;
            return this;
        }
        
        public Perk WithSecondaryRole(SkillEffect.PerkRole role)
        {
            SecondaryRole = role;
            return this;
        }

        public Perk WithAddIncrementType()
        {
            IncrementType = SkillEffect.EffectIncrementType.Add;
            return this;
        }

        public Perk WithAddFactorIncrementType()
        {
            IncrementType = SkillEffect.EffectIncrementType.AddFactor;
            return this;
        }
    }
}