using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace BannerLib.Gameplay.Perks
{
    public class PerkBuilder
    {
        private readonly Game m_game;
        private readonly string m_modNamePrefix;
        private readonly SkillObject m_skillGroup;
        private readonly int m_perkLevel;

        private Perk m_perk;
        private PerkObject m_perkObject;
        private Perk m_alternativePerk;
        private PerkObject m_alternativePerkObject;
        private bool m_isCreatedFromExisting;
        
        internal PerkBuilder(Game game, string modName, SkillObject skillGroup, int perkLevel)
        {
            m_game = game;
            m_modNamePrefix = $"{modName}_";
            m_skillGroup = skillGroup;
            m_perkLevel = perkLevel;
        }
        
        public static PerkBuilder Create(Game game, string modName, SkillObject skillGroup, int perkLevel)
        {
            return new PerkBuilder(game, modName, skillGroup, perkLevel);
        }

        public static PerkBuilder CreateFromExisting(Game game, string modName, PerkObject existingPerk)
        {
            var newPerkBuilder = new PerkBuilder(game, modName, existingPerk.Skill, (int)existingPerk.RequiredSkillValue);
            newPerkBuilder.m_perk = new Perk(existingPerk.Name.ToString(), existingPerk.Description.ToString(), existingPerk);
            newPerkBuilder.m_perkObject = existingPerk;
            newPerkBuilder.m_isCreatedFromExisting = true;
            return newPerkBuilder;
        }

        public Perk CreatePerk(string perkId, string displayName, string description, bool throwExceptionOnPerkExists = true)
        {
            if(!(m_perk is null)) 
                throw new InvalidOperationException($"An alternative perk \"{m_perk.Name}\" exists in this builder.");
            m_perkObject = CreatePerkObject(perkId, throwExceptionOnPerkExists);
            if (m_perkObject is null) return null;
            m_perk = new Perk(displayName, description, m_perkObject);
            return m_perk;
        }

        public Perk CreateAlternativePerk(string perkId, string displayName, string description, bool throwExceptionOnPerkExists = true)
        {
            if(!(m_alternativePerk is null)) 
                throw new InvalidOperationException($"An alternative perk \"{m_alternativePerk.Name}\" exists in this builder.");
            m_alternativePerkObject = CreatePerkObject(perkId, throwExceptionOnPerkExists);
            if (m_alternativePerkObject is null) return null;
            m_alternativePerk = new Perk(displayName, description, m_alternativePerkObject);
            return m_alternativePerk;
        }
        
        public (Perk main, Perk alternative) Build()
        {
            if(!m_isCreatedFromExisting)
                InitializePerk(m_perk, m_perkObject, m_alternativePerkObject);
            if(!(m_alternativePerk is null))
                InitializePerk(m_alternativePerk, m_alternativePerkObject, m_perkObject);
            UpdatePerks();
            return (m_perk, m_alternativePerk);
        }
        
        private static void UpdatePerks()
        {
            foreach (var hero in Hero.All)
            {
                hero.HeroDeveloper.Call("DiscoverOpenedPerks");
            }
        }

        private PerkObject CreatePerkObject(string perkId, bool throwExceptionOnPerkExists)
        {
            if (m_game.ObjectManager.GetObject<PerkObject>(m_modNamePrefix + perkId) != null)
            {
                if(throwExceptionOnPerkExists) 
                    throw new Exception($"A perk with the id {perkId} already exists - {m_modNamePrefix}{perkId}");
                return null;
            }
            var newPerkObj = new PerkObject(perkId);
            m_game.ObjectManager.RegisterPresumedObject(newPerkObj);
            return newPerkObj;
        }

        private void InitializePerk(Perk perk, PerkObject perkObject, PerkObject alternatePerk)
        {
            perkObject.Initialize(perk.Name, 
                perk.Description, 
                m_skillGroup, 
                m_perkLevel, 
                alternatePerk, 
                perk.PrimaryRole, 
                perk.PrimaryBonus,
                perk.SecondaryRole, 
                perk.SecondaryBonus,
                perk.EffectType);
        }
    }
}
