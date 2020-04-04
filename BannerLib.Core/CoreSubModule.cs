using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerLib.Core
{
    public class CoreSubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            InformationManager.DisplayMessage(new InformationMessage("BannerLib Loaded."));
        }
    }
}