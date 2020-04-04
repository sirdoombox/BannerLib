using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace BannerLib.Gameplay.Perks
{
    public class Perk
    {
        public string Name { get; }
        public string Description { get; }
        public float PrimaryBonus { get; private set; }
        public float SecondaryBonus { get; private set; }
        public SkillEffect.PerkRole PrimaryRole { get; private set; }
        public SkillEffect.PerkRole SecondaryRole { get; private set; }
        public SkillEffect.EffectIncrementType EffectType { get; private set; }
        
        internal PerkObject PerkObject { get; }

        internal Perk(string name, string description, PerkObject perkObject)
        {
            Name = name;
            Description = description;
            PerkObject = perkObject;
            PrimaryBonus = perkObject.PrimaryBonus;
            PrimaryRole = perkObject.PrimaryRole;
            SecondaryRole = perkObject.SecondaryRole;
            SecondaryBonus = perkObject.SecondaryBonus;
            EffectType = perkObject.IncrementType;
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

        public Perk WithEffectType(SkillEffect.EffectIncrementType effectType)
        {
            EffectType = effectType;
            return this;
        }

        public static implicit operator PerkObject(Perk perk) => perk.PerkObject;
    }
}