using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace BannerLib.Core
{
    public class CoreSubModule : MBSubModuleBase
    {
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            InformationManager.DisplayMessage(new InformationMessage("Loaded BannerLib", Colors.Green));
        }
    }
}