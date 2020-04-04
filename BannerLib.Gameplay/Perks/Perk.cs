using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace BannerLib.Gameplay.Perks
{
    /// <summary>
    /// Describes a Perk available to characters in the game.
    /// This type is implicitly convertible to <see cref="PerkObject"/> so it can be used in all the same places that it would be.
    /// </summary>
    public class Perk
    {
        /// <summary>
        /// Display name of the perk.
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Description of the perk as seen in the character screen.
        /// </summary>
        public string Description { get; }
        
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

        private readonly PerkObject m_perkObject;

        internal Perk(string name, string description, PerkObject perkObject)
        {
            Name = name;
            Description = description;
            m_perkObject = perkObject;
            PrimaryBonus = perkObject.PrimaryBonus;
            PrimaryRole = perkObject.PrimaryRole;
            SecondaryRole = perkObject.SecondaryRole;
            SecondaryBonus = perkObject.SecondaryBonus;
            EffectType = perkObject.IncrementType;
        }

        /// <summary>
        /// Converts a <see cref="Perk"/> object to a <see cref="PerkObject"/> implicitly so it can be used in all the same places.
        /// </summary>
        /// <param name="perk">Perk to convert.</param>
        /// <returns>Internally stored PerkObject.</returns>
        public static implicit operator PerkObject(Perk perk) => perk.m_perkObject;
    }
}