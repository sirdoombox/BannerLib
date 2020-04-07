using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace BannerLib.Gameplay.Models
{
    /// <summary>
    /// Allows all mods to add/replace GameModels centrally, with records to show what has been replaced.
    /// </summary>
    public class ModelManager
    {
        private readonly string m_modName;
        private readonly IGameStarter m_gameStarter;
        private List<GameModel> GameModels => (List<GameModel>) m_gameStarter.Models;

        // model ledgers so we can at least try to resolve mod conflicts.
        private static readonly List<ReplacedModelInfo> ReplacedModelLedger = new List<ReplacedModelInfo>();
        private static readonly List<AddedModelInfo> AddedModelLedger = new List<AddedModelInfo>();

        /// <summary>
        /// Get a record of all Model replacement operations.
        /// </summary>
        public IReadOnlyList<ReplacedModelInfo> ReplacedModels => ReplacedModelLedger;
        
        /// <summary>
        /// Get a record of all Model addition operations.
        /// </summary>
        public IReadOnlyList<AddedModelInfo> AddedModels = AddedModelLedger;
        
        public ModelManager(string modName, IGameStarter gameStarter)
        {
            m_modName = modName;
            m_gameStarter = gameStarter;
        }

        /// <summary>
        /// Check if a GameModel derived base class has had it's implementation replaced.
        /// </summary>
        /// <typeparam name="TModelBase">Type to check E.G.: <see cref="TaleWorlds.CampaignSystem.GenericXpModel"/></typeparam>
        /// <returns>A <see cref="ReplacedModelInfo"/> object describing the replacement, or null if no replacement was made.</returns>
        public ReplacedModelInfo IsModelReplaced<TModelBase>() where TModelBase : GameModel
        {
            return ReplacedModelLedger.FirstOrDefault(x => x.BaseType == typeof(TModelBase));
        }
        
        /// <summary>
        /// Check if a model implementation exists for a given type.
        /// </summary>
        /// <typeparam name="TModelBase"></typeparam>
        /// <returns></returns>
        public bool ModelExistsFor<TModelBase>() where TModelBase : GameModel
        {
            return GameModels.Any(x => x is TModelBase);
        }

        /// <summary>
        /// Add a model to the game, other mods can replace this model as if it were any other.
        /// </summary>
        /// <param name="toAdd"></param>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TBase"></typeparam>
        public void AddModel<TModel, TBase>(TModel toAdd) where TModel : TBase where TBase : GameModel
        {
            if (AddedModelLedger.Any(x => x.AddedType == typeof(TModel)))
                throw new Exception($"Model of type {typeof(TModel).Name} already exists.");
            m_gameStarter.AddModel(toAdd);
            AddedModelLedger.Add(new AddedModelInfo(m_modName, typeof(TModel), typeof(TBase)));
        }

        /// <summary>
        /// Replaces ALL instances of Models that derive from <see cref="TBaseReplace"/>.
        /// This is hugely destructive so expect things to break if you don't know what you're doing.
        /// </summary>
        /// <param name="toReplace"></param>
        /// <typeparam name="TBaseReplace"></typeparam>
        /// <typeparam name="TReplacement"></typeparam>
        /// <exception cref="Exception"></exception>s
        public void ReplaceAll<TBaseReplace, TReplacement>(TReplacement toReplace) 
            where TBaseReplace : GameModel where TReplacement : GameModel
        {
            var baseType = typeof(TBaseReplace);
            var addType = typeof(TReplacement);
            if (!baseType.IsAssignableFrom(addType))
                throw new Exception($"{addType.Name} is not derived from {baseType.Name}");
            if (!GameModels.Any(x => x is TBaseReplace)) return;
            var models = GameModels.Where(x => x is TBaseReplace);
            GameModels.RemoveAll(x => x is TBaseReplace);
            ReplacedModelLedger.AddRange(models.Select(x => new ReplacedModelInfo(m_modName, baseType, x.GetType(), addType)));
            m_gameStarter.AddModel(toReplace);
        }

        public void Replace<TReplace, TReplacement>(TReplacement replacement)
            where TReplace : GameModel where TReplacement : GameModel
        {
            var replaceType = typeof(TReplace);
            var replacementType = typeof(TReplacement);
            if(replaceType.BaseType is null) 
                throw new Exception($"{replaceType.Name} must derive from something.");
            if(replacementType.BaseType is null) 
                throw new Exception($"{replacementType.Name} must derive from something.");
            if(!replaceType.BaseType.IsAssignableFrom(replacementType))
                throw new Exception($"{replaceType.Name} is not derived from {replacementType.BaseType.Name}");
            if (!GameModels.Any(x => x is TReplace)) return;
            var model = GameModels.First(x => x is TReplace);
            GameModels.Remove(model);
            ReplacedModelLedger.Add(new ReplacedModelInfo(m_modName, replaceType.BaseType, replaceType, replacementType));
            m_gameStarter.AddModel(replacement);
        }

        /// <inheritdoc cref="ReplaceAll{TBase,TAdd}(TAdd)"/>
        public void ReplaceAll<TRemove, TAdd>() where TRemove : GameModel where TAdd : GameModel, new() =>
            ReplaceAll<TRemove, TAdd>(new TAdd());
    }
}