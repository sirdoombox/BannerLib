using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace BannerLib.Gameplay.Perks
{
    public class PerkCreator
    {
        private readonly string m_modName;
        private readonly Game m_game;
        
        public PerkCreator(Game game, string modName)
        {
            m_game = game;
            m_modName = modName;
        }

        public T Register<T>(string id) where T : PerkBase, new()
        {
            var registeredPerk = RegisterInternal(new T(), id);
            InitializePerk(registeredPerk);
            return registeredPerk;
        }

        public (TFirst, TSecond) RegisterAlternatives<TFirst, TSecond>(string idFirst, string idSecond)
            where TFirst : PerkBase, new() where TSecond : PerkBase, new()
        {
            var firstPerk = new TFirst();
            var secondPerk = new TSecond();
            var registeredFirst = RegisterInternal(firstPerk, idFirst);
            var registeredSecond = RegisterInternal(secondPerk, idSecond);
            InitializePerk(registeredFirst, registeredSecond);
            return (registeredFirst, registeredSecond);
        }

        public T Register<T>() where T : PerkBase, new() =>
            Register<T>(typeof(T).Name);

        public (TFirst, TSecond) RegisterAlternatives<TFirst, TSecond>()
            where TFirst : PerkBase, new() where TSecond : PerkBase, new() =>
            RegisterAlternatives<TFirst, TSecond>(typeof(TFirst).Name, typeof(TSecond).Name);
        
        public void UpdatePerks()
        {
            foreach (var hero in Hero.All)
                hero.HeroDeveloper.Call("DiscoverOpenedPerks");
        }
        
        private T RegisterInternal<T>(T perkBase, string id) where T : PerkBase, new()
        {
            var perkId = $"{m_modName}_{id}";
            var perkObject = m_game.ObjectManager.GetObject<PerkObject>(perkId);
            if (!(perkObject is null))
            {
                // This seems to no longer work for literally no reason.
                // IMPORTANT: For some reason the game is now completely incapable of loading up perks properly
                // IMPORTANT: Beats me.
                perkBase.m_perkObject = perkObject;
                perkBase.InitWithPerkObject();
                perkBase.m_perkAlreadyExisted = true;
            }
            else
            {
                perkBase.m_perkObject = m_game.ObjectManager.RegisterPresumedObject(new PerkObject(perkId));
            }
            return perkBase;
        }

        private void InitializePerk(PerkBase perk, PerkBase alternate = null)
        {
            if (!perk.m_perkAlreadyExisted)
                perk.m_perkObject.Initialize(perk.Name,
                    perk.Description,
                    perk.Skill,
                    perk.PerkSkillRequirement,
                    alternate?.m_perkObject,
                    perk.PrimaryRole,
                    perk.PrimaryBonus,
                    perk.SecondaryRole,
                    perk.SecondaryBonus,
                    perk.EffectType);
            if (alternate != null && !alternate.m_perkAlreadyExisted)
                alternate.m_perkObject.Initialize(alternate.Name,
                    alternate.Description,
                    alternate.Skill,
                    alternate.PerkSkillRequirement,
                    perk.m_perkObject,
                    alternate.PrimaryRole,
                    alternate.PrimaryBonus,
                    alternate.SecondaryRole,
                    alternate.SecondaryBonus,
                    alternate.EffectType);
        }
    }
}