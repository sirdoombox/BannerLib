using TaleWorlds.CampaignSystem;

namespace BannerLib.Gameplay.Perks
{
    public class PerkConstructor : Perk
    {
        internal PerkConstructor(string name, string description, PerkObject perkObject) : base(name, description, perkObject)
        {
        }
        
        /// <inheritdoc cref="Perk.PrimaryBonus"/>
        public PerkConstructor WithPrimaryBonus(float bonus)
        {
            PrimaryBonus = bonus;
            return this;
        }
        
        /// <inheritdoc cref="Perk.PrimaryRole"/>
        public PerkConstructor WithPrimaryRole(SkillEffect.PerkRole role)
        {
            PrimaryRole = role;
            return this;
        }
        
        /// <inheritdoc cref="Perk.SecondaryBonus"/>
        public PerkConstructor WithSecondaryBonus(float bonus)
        {
            SecondaryBonus = bonus;
            return this;
        }
        
        /// <inheritdoc cref="Perk.SecondaryRole"/>
        public PerkConstructor WithSecondaryRole(SkillEffect.PerkRole role)
        {
            SecondaryRole = role;
            return this;
        }
        
        /// <inheritdoc cref="Perk.EffectType"/>
        public PerkConstructor WithEffectType(SkillEffect.EffectIncrementType effectType)
        {
            EffectType = effectType;
            return this;
        }
    }
}