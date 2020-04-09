using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace BannerLib.Gameplay.Models
{
    /// <summary>
    /// A class designed to make adding/replacing <see cref="GameModel"/>s a less cumbersome and dangerous task.
    /// </summary>
    public static class GameModels
    {
        /// <summary>
        /// Keeps a record of all model additions/replacements, hopefully helping you prevent crashes for your mod.
        /// </summary>
        public static IReadOnlyList<GameModelLedgerEntry> Ledger => m_ledger;
        private static readonly List<GameModelLedgerEntry> m_ledger = new List<GameModelLedgerEntry>();
        
        /// <summary>
        /// Check if a GameModel derived base class has had it's implementation replaced.
        /// </summary>
        /// <typeparam name="TModelBase">Type to check E.G.: <see cref="TaleWorlds.CampaignSystem.GenericXpModel"/></typeparam>
        /// <returns>A <see cref="GameModelLedgerEntry"/> object describing the replacement, or null if no replacement was made.</returns>
        public static GameModelLedgerEntry IsModelReplaced<TModelBase>() where TModelBase : GameModel
        {
            return m_ledger.FirstOrDefault(x => x.BaseType == typeof(TModelBase));
        }
        
        /// <summary>
        /// Check if a model implementation exists for a given base type.
        /// </summary>
        /// <param name="starter"><see cref="IGameStarter"/> Object.</param>
        /// <typeparam name="TModelBase"><see cref="GameModel"/> Derived base class to check for.</typeparam>
        /// <returns>True if a model that derives from the given type exists in the current models.</returns>
        public static bool ModelExistsFor<TModelBase>(this IGameStarter starter) where TModelBase : GameModel
        {
            return starter.Models.Any(x => x is TModelBase);
        }
        
        /// <summary>
        /// Replace a specific GameModel implementation with another.
        /// </summary>
        /// <param name="starter"><see cref="IGameStarter"/> Object.</param>
        /// <param name="replacement">Specific instance of a <see cref="GameModel"/> derived type to use as the replacement.</param>
        /// <typeparam name="TReplace"><see cref="GameModel"/> derived type to use as the replace.</typeparam>
        /// <typeparam name="TReplacement"><see cref="GameModel"/> derived type to use as the replacement.</typeparam>
        public static void Replace<TReplace,TReplacement>(this IGameStarter starter, TReplacement replacement) 
            where TReplace : GameModel where TReplacement : GameModel
        {
            var replaceType = typeof(TReplace);
            var replacementType = typeof(TReplacement);
            if(replaceType.BaseType is null) 
                throw new Exception($"{replaceType.Name} must derive from something.");
            if(replacementType.BaseType is null) 
                throw new Exception($"{replacementType.Name} must derive from something.");
            if(!replaceType.BaseType.IsAssignableFrom(replacementType) &&
               !(replacementType.BaseType != replaceType))
                throw new Exception($"{replaceType.Name} is not derived from {replacementType.BaseType.Name}");
            var model = starter.Models.FirstOrDefault(x => x is TReplace);
            if (model is null) return;;
            ((List<GameModel>)starter.Models).Remove(model);
            starter.AddModel(replacement);
            m_ledger.Add(new GameModelLedgerEntry(replaceType, replacementType));
        }
        
        /// <summary>
        /// Replace a specific GameModel implementation with another.
        /// </summary>
        /// <param name="starter"><see cref="IGameStarter"/> Object.</param>
        /// <typeparam name="TReplace"><see cref="GameModel"/> Derived base class to replace E.G.: <seealso cref="DefaultGenericXpModel"/></typeparam>
        /// <typeparam name="TReplacement"><see cref="GameModel"/> derived type to use as the replacement.</typeparam>
        public static void Replace<TReplace, TReplacement>(this IGameStarter starter)
            where TReplace : GameModel where TReplacement : GameModel, new() =>
            Replace<TReplace, TReplacement>(starter, new TReplacement());
        
        /// <summary>
        /// Replace all GameModel implementations of a certain base type with a specified one.
        /// </summary>
        /// <param name="starter"><see cref="IGameStarter"/> Object.</param>
        /// <param name="replacement">Instance of a <see cref="GameModel"/> derived type to use as the replacement.</param>
        /// <typeparam name="TBaseReplace"><see cref="GameModel"/> Derived base class to replace E.G.: <seealso cref="GenericXpModel"/></typeparam>
        /// <typeparam name="TReplacement"><see cref="GameModel"/> derived type to use as the replacement.</typeparam>
        public static void ReplaceAll<TBaseReplace, TReplacement>(this IGameStarter starter, TReplacement replacement)
            where TBaseReplace : GameModel where TReplacement : GameModel
        {
            var baseType = typeof(TBaseReplace);
            var addType = typeof(TReplacement);
            if (!baseType.IsAssignableFrom(addType))
                throw new Exception($"{addType.Name} is not derived from {baseType.Name}");
            var models = starter.Models.Where(x => x is TBaseReplace);
            if (models.IsEmpty()) return;
            ((List<GameModel>)starter.Models).RemoveAll(x => x is TBaseReplace);
            starter.AddModel(replacement);
            m_ledger.AddRange(models.Select(x => new GameModelLedgerEntry(x.GetType(), addType)));
        }
        
        /// <summary>
        /// Replace all GameModel implementations of a certain base type with a specified one.
        /// </summary>
        /// <param name="starter"><see cref="IGameStarter"/> Object.</param>
        /// <typeparam name="TBaseReplace"><see cref="GameModel"/> base type to replace all derived types for.</typeparam>
        /// <typeparam name="TReplacement"><see cref="GameModel"/> derived type to use as the replacement.</typeparam>
        public static void ReplaceAll<TBaseReplace, TReplacement>(this IGameStarter starter)
            where TBaseReplace : GameModel where TReplacement : GameModel, new() =>
            ReplaceAll<TBaseReplace, TReplacement>(starter, new TReplacement());

        /// <summary>
        /// Decorates an existing model with a given decorator that is produced by the given function
        /// </summary>
        /// <typeparam name="TDecoratee"><see cref="GameModel"/> derived type to decorate.</typeparam>
        /// <typeparam name="TDecorater"><see cref="GameModel"/> derived type that will decorate it.</typeparam>
        /// <param name="starter"><see cref="IGameStarter"/> Object.</param>
        /// <param name="decoraterCtor">Functions which creates the decorator from the given model</param>
        public static void Decorate<TDecoratee, TDecorater>(this IGameStarter starter, Func<TDecoratee, TDecorater> decoraterCtor)
            where TDecoratee : GameModel where TDecorater : TDecoratee
        {
            var baseType = typeof(TDecoratee);
            var model = starter.Models
                .OfType<TDecoratee>()
                .SingleOrDefault();
            if (model == null)
                throw new ArgumentException($"No model or multiple models registered with type '{baseType.Name}'. It must be exactly ONE model with this type to decorate it!");
            var decorater = decoraterCtor(model);
            starter.Replace<TDecoratee, TDecorater>(decorater);
            m_ledger.Add(new GameModelLedgerEntry(typeof(TDecoratee), typeof(TDecorater)));
        }
        
        /// <summary>
        /// Adds a GameModel to the GameStarter
        /// - This CAN (but might not) cause unintended effects if you add a model that already exists.
        /// </summary>
        /// <param name="starter"><see cref="IGameStarter"/> Object.</param>
        /// <param name="add">Instance of the <see cref="GameModel"/> derived type to add.</param>
        /// <typeparam name="TGameModel"><see cref="GameModel"/> derived type to add.</typeparam>
        public static void Add<TGameModel>(this IGameStarter starter, TGameModel add)
            where TGameModel : GameModel
        {
            starter.AddModel(add);
            m_ledger.Add(new GameModelLedgerEntry(null, typeof(TGameModel)));
        }

        /// <summary>
        /// Adds a GameModel to the GameStarter
        /// - This CAN (but might not) cause unintended effects if you add a model that already exists.
        /// </summary>
        /// <param name="starter"><see cref="IGameStarter"/> Object.</param>
        /// <typeparam name="TGameModel"><see cref="GameModel"/> derived type to add.</typeparam>
        public static void Add<TGameModel>(this IGameStarter starter) 
            where TGameModel : GameModel, new() =>
            Add(starter, new TGameModel());
    }
}