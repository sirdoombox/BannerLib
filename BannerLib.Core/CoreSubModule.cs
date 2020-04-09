using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace BannerLib.Core
{
    public class CoreSubModule : MBSubModuleBase
    {
        private bool m_isLoaded;
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            if (m_isLoaded) return;
            m_isLoaded = true;
            InformationManager.DisplayMessage(new InformationMessage("Loaded BannerLib", Colors.Green));
        }
    }
}