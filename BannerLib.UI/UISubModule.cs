using BannerLib.UI.Map;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection;

#pragma warning disable 1591

namespace BannerLib.UI
{
    public class UISubModule : MBSubModuleBase
    {
        public override void OnGameInitializationFinished(Game game)
        {
            // Just testing this out...
            MapEscapeMenu.Add(new EscapeMenuItemVM(new TextObject("Test 1"), _ => { }, null, false));
            MapEscapeMenu.Add(new EscapeMenuItemVM(new TextObject("Test 2"), _ => { }, null, false));
            MapEscapeMenu.Insert(0, new EscapeMenuItemVM(new TextObject("Test Insert Top"), _ => { }, null, false));
        }
    }
}