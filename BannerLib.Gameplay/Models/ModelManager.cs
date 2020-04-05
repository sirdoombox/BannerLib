using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.Core;

namespace BannerLib.Gameplay.Models
{
    /// <summary>
    /// Allows you to Add/Replace models, whilst handling conflicts with other mods.
    /// Also allows other mods to replace your models.
    /// </summary>
    public class ModelManager
    {
        private readonly string m_modName;
        private readonly IGameStarter m_gameStarter;
        private List<GameModel> GameModels => (List<GameModel>) m_gameStarter.Models;

        // model ledgers so we can at least try to resolve mod conflicts.
        private static readonly List<ReplacedModelInfo> s_replacedModelLedger =
            new List<ReplacedModelInfo>();
        
        private static readonly List<AddedModelInfo> s_addedModelLedger =
            new List<AddedModelInfo>();

        public ModelManager(string modName, IGameStarter gameStarter)
        {
            m_modName = modName;
            m_gameStarter = gameStarter;
        }

        /// <summary>
        /// Check if a GameModel base class has had it's implementation replaced.
        /// </summary>
        /// <typeparam name="TModelBase">Type to check E.G.: <see cref="TaleWorlds.CampaignSystem.GenericXpModel"/></typeparam>
        /// <returns>A <see cref="ReplacedModelInfo"/> object describing the replacement, or null if no replacement was made.</returns>
        public ReplacedModelInfo IsModelReplaced<TModelBase>() where TModelBase : GameModel
        {
            return s_replacedModelLedger.FirstOrDefault(x => x.BaseType == typeof(TModelBase));
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
            if (s_addedModelLedger.Any(x => x.AddedType == typeof(TModel)))
                throw new Exception($"Model of type {typeof(TModel).Name} already exists.");
            m_gameStarter.AddModel(toAdd);
            s_addedModelLedger.Add(new AddedModelInfo(m_modName, typeof(TModel), typeof(TBase)));
        }

        /// <summary>
        /// Replaces ALL instances of Models that derive from <see cref="TBaseReplace"/>.
        /// This is hugely destructive so expect things to break if you don't know what you're doing.
        /// </summary>
        /// <param name="toAdd"></param>
        /// <typeparam name="TBaseReplace"></typeparam>
        /// <typeparam name="TReplacement"></typeparam>
        /// <exception cref="Exception"></exception>
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
            s_replacedModelLedger.AddRange(models.Select(x => new ReplacedModelInfo(m_modName, baseType, x.GetType(), addType)));
            m_gameStarter.AddModel(toReplace);
        }

        /// <summary>
        /// Reverts a model replacement back to it's previous model.
        /// </summary>
        /// <typeparam name="TFor"></typeparam>
        public void RevertReplacement<TFor>() where TFor : GameModel
        {
            var replacedModel = s_replacedModelLedger.FirstOrDefault(x => x.ReplacedType == typeof(TFor));
            if (replacedModel is null) return;
        }

        /// <inheritdoc cref="ReplaceAll{TBase,TAdd}(TAdd)"/>
        public void ReplaceAll<TRemove, TAdd>() where TRemove : GameModel where TAdd : GameModel, new() =>
            ReplaceAll<TRemove, TAdd>(new TAdd());
    }
}