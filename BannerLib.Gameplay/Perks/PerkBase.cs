using System;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace BannerLib.Gameplay.Perks
{
    public class PerkBase
    {
        /// <summary>
        /// Display name of the perk.
        /// </summary>
        public string Name { get; internal set; }
        
        /// <summary>
        /// Description of the perk as seen in the character screen.
        /// </summary>
        public string Description { get; internal set; }
        
        /// <summary>
        /// The primary bonus value. If <see cref="EffectType"/> is set to AddFactor, this number should be expressed as a percentage.
        /// </summary>
        public float PrimaryBonus { get; protected set; }
        
        /// <summary>
        /// The Secondary bonus value. If <see cref="EffectType"/> is set to AddFactor, this number should be expressed as a percentage.
        /// </summary>
        public float SecondaryBonus { get; protected set; }
        
        /// <summary>
        /// The Primary Role for the perk.
        /// </summary>
        public SkillEffect.PerkRole PrimaryRole { get; protected set; }
        
        /// <summary>
        /// The Secondary Role for the perk.
        /// </summary>
        public SkillEffect.PerkRole SecondaryRole { get; protected set; }
        
        /// <summary>
        /// The way in which these bonuses are applied - "Add" adds bonuses as a flat value, whilst "AddFactor" is added as a percentage.
        /// </summary>
        public SkillEffect.EffectIncrementType EffectType { get; protected set; }
        
        /// <summary>
        /// The skill group this perk belongs to.
        /// </summary>
        public SkillObject Skill { get; protected set; }
        
        /// <summary>
        /// The skill level requirement for this perk.
        /// </summary>
        public int PerkSkillRequirement { get; protected set; }

        /// <summary>
        /// Converts a <see cref="Perk"/> object to a <see cref="PerkObject"/> implicitly so it can be used in all the same places.
        /// </summary>
        /// <param name="perk">Perk to convert.</param>
        /// <returns>Internally stored PerkObject.</returns>
        public static implicit operator PerkObject(PerkBase perk) => perk.m_perkObject;
        
        internal PerkObject m_perkObject;
        internal bool m_perkFromExisting = false;

        internal void InitWithPerkObject()
        {
            if (m_perkObject.Name == null) return;
            Name = m_perkObject.Name.ToString();
            Description = m_perkObject.Description.ToString();
            PrimaryBonus = m_perkObject.PrimaryBonus;
            PrimaryRole = m_perkObject.PrimaryRole;
            SecondaryRole = m_perkObject.SecondaryRole;
            SecondaryBonus = m_perkObject.SecondaryBonus;
            EffectType = m_perkObject.IncrementType;
            Skill = m_perkObject.Skill;
            PerkSkillRequirement = (int)Math.Round(m_perkObject.RequiredSkillValue);
        }

        protected internal PerkBase()
        {
            PrimaryBonus = default;
            PrimaryRole = SkillEffect.PerkRole.None;
            SecondaryBonus = default;
            SecondaryRole = SkillEffect.PerkRole.None;
            EffectType = SkillEffect.EffectIncrementType.Add;
            Skill = DefaultSkills.GetAllSkills().First();
        }
    }
}