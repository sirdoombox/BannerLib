using System.Collections.Generic;
using TaleWorlds.Core;

namespace BannerLib.Gameplay
{
    /// <summary>
    /// 
    /// </summary>
    public static class ModelSystem
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameStarter"></param>
        /// <param name="toAdd"></param>
        /// <typeparam name="TRemove"></typeparam>
        public static void ReplaceModel<TRemove>(IGameStarter gameStarter, GameModel toAdd)
        {
            ((List<GameModel>) gameStarter.Models).RemoveAll(item => item is TRemove);
            gameStarter.AddModel(toAdd);
        }
    }
}
