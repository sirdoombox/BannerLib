using BannerLib.Gameplay.Models;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
#pragma warning disable 1591

namespace BannerLib.Gameplay
{
    public class GameplaySubModule : MBSubModuleBase
    {
        // STUB: Used purely to get the submodules to load correctly. (For Now)

        public override void OnGameLoaded(Game game, object initializerObject)
        {
            RunTest(game,(IGameStarter)initializerObject);
        }

        public override void OnCampaignStart(Game game, object starterObject)
        {
            RunTest(game,(IGameStarter)starterObject);
        }

        private void RunTest(Game game, IGameStarter starter)
        {
            if(!(game.GameType is Campaign)) return;
            var manager = new ModelManager("testMod", starter);
            manager.Replace<DefaultGenericXpModel, DifferentXpModel>();
            manager.Replace<DefaultCombatXpModel, DifferentXpModel>();
        }
    }
    
    public class DifferentXpModel : GenericXpModel
    {
        public override float GetXpMultiplier(Hero hero)
        {
            return 2f;
        }
    }
}