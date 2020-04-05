using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace BannerLib.Gameplay.Perks
{
    /// <summary>
    /// The class used to register perks with the system.
    /// </summary>
    public class PerkCreator
    {
        private readonly string m_modName;
        private readonly Game m_game;

        /// <summary>
        /// Initialize a new instance of the <see cref="PerkCreator"/> class for your mod.
        /// </summary>
        /// <param name="game">The game that you plan to add perks to.</param>
        /// <param name="modName">The name of your mod, this should be constant, any changes between sessions will
        /// cause issues.</param>
        public PerkCreator(Game game, string modName)
        {
            m_game = game;
            m_modName = modName;
        }

        /// <summary>
        /// Register a perk with bannerlord.
        /// </summary>
        /// <param name="id">The ID of the perk, this should be unique and consistent, inconsistency between sessions
        /// will cause problems.</param>
        /// <typeparam name="T">The PerkBase derived class to create a perk from.</typeparam>
        /// <returns>A new instance of your PerkBase derived class that is fully initialised.</returns>
        public T Register<T>(string id) where T : PerkBase, new()
        {
            var registeredPerk = RegisterInternal(new T(), id);
            InitializePerk(registeredPerk);
            return registeredPerk;
        }

        /// <summary>
        /// Register two perks with bannerlord that are alternatives to one another, so in the character screen you
        /// would have to make a choice between the two.
        /// </summary>
        /// <param name="idFirst">The ID of the first perk, this should be unique and consistent, inconsistency
        /// between sessions will cause problems.</param>
        /// <param name="idSecond">The ID of the second perk, this should be unique and consistent, inconsistency
        /// between sessions will cause problems.</param>
        /// <typeparam name="TFirst">The first PerkBase derived class to create a perk from.</typeparam>
        /// <typeparam name="TSecond">The second PerkBase derived class to create a perk from.</typeparam>
        /// <returns>New instances of your PerkBase derived classes that are ready to use.</returns>
        public (TFirst, TSecond) RegisterAlternatives<TFirst, TSecond>(string idFirst, string idSecond)
            where TFirst : PerkBase, new() where TSecond : PerkBase, new()
        {
            var registeredFirst = RegisterInternal(new TFirst(), idFirst);
            var registeredSecond = RegisterInternal(new TSecond(), idSecond);
            InitializePerk(registeredFirst, registeredSecond);
            return (registeredFirst, registeredSecond);
        }

        /// <summary>
        /// Registers a new perk as an alternative for one that already exists in the base game.
        /// </summary>
        /// <param name="id">The ID of the perk, this should be unique and consistent,
        /// inconsistency between sessions will cause problems.</param>
        /// <param name="existingPerk">A PerkObject that already exists - See <see cref="DefaultPerks"/> for a full list.</param>
        /// <typeparam name="TNew">The PerkBase derived class to create a perk from.</typeparam>
        /// <returns>A new instance of your PerkBase derived class that are ready to use, and a PerkBase for the existing perk.</returns>
        public (TNew, PerkBase) RegisterAlternativeForExistingPerk<TNew>(string id, PerkObject existingPerk)
            where TNew : PerkBase, new()
        {
            var existing = new PerkBase();
            existing.m_perkObject = existingPerk;
            existing.InitWithPerkObject();
            existing.m_perkFromExisting = true;
            var registeredNew = RegisterInternal(new TNew(), id);
            InitializePerk(registeredNew, existing);
            return (registeredNew, existing);
        }

        /// <summary>
        /// Functions just like <see cref="Register{T}(string)"/>
        /// however the name of your PerkBase derived type is used as the ID.
        /// </summary>
        /// <typeparam name="T">The PerkBase derived class to create a perk from.</typeparam>
        /// <returns>A new instance of your PerkBase derived class that is fully initialised.</returns>
        public T Register<T>() where T : PerkBase, new() =>
            Register<T>(typeof(T).Name);

        /// <summary>
        /// Functions just like <see cref="RegisterAlternatives{TFirst,TSecond}(string,string)"/>
        /// however the names of your PerkBase derived types are used as the ID.
        /// </summary>
        /// <typeparam name="TFirst">The first PerkBase derived class to create a perk from.</typeparam>
        /// <typeparam name="TSecond">The Second PerkBase derived class to create a perk from.</typeparam>
        /// <returns>New instances of your PerkBase derived classes that are ready to use.</returns>
        public (TFirst, TSecond) RegisterAlternatives<TFirst, TSecond>()
            where TFirst : PerkBase, new() where TSecond : PerkBase, new() =>
            RegisterAlternatives<TFirst, TSecond>(typeof(TFirst).Name, typeof(TSecond).Name);

        /// <summary>
        /// Functions just like <see cref="RegisterAlternativeForExistingPerk{TNew}(string,TaleWorlds.CampaignSystem.PerkObject)"/>
        /// however the names of your PerkBase derived types are used as the ID.
        /// </summary>
        /// <param name="existingPerk">A PerkObject that already exists - See <see cref="DefaultPerks"/>
        /// for a full list.</param>
        /// <typeparam name="TNew">The PerkBase derived class to create a perk from.</typeparam>
        /// <returns>A new instance of your PerkBase derived class that are ready to use, and a PerkBase for the existing perk.</returns>
        public (TNew, PerkBase) RegisterAlternativeForExistingPerk<TNew>(PerkObject existingPerk)
            where TNew : PerkBase, new() =>
            RegisterAlternativeForExistingPerk<TNew>(typeof(TNew).Name, existingPerk);

        /// <summary>
        /// Call this once you're done registering all your perks.
        /// </summary>
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
                perkBase.m_perkObject = perkObject;
            }
            else
            {
                perkBase.m_perkObject = m_game.ObjectManager.RegisterPresumedObject(new PerkObject(perkId));
            }

            return perkBase;
        }

        private static void InitializePerk(PerkBase perk, PerkBase alternate = null)
        {
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
            if (alternate != null && alternate.m_perkFromExisting) return;
            alternate?.m_perkObject.Initialize(alternate.Name,
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