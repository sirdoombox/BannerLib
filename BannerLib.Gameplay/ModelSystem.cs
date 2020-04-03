using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;

namespace BannerLib.Gameplay
{
    public class ModelSystem
    {
        public void ReplaceModel<TRemove>(IGameStarter gameStarter, GameModel toAdd)
        {
            Utils.Remove<GameModel, TRemove>(gameStarter.Models as List<GameModel>);
            gameStarter.AddModel(toAdd);
        }
    }
}
