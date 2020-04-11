using System.Linq;
using BannerLib.UI.Map;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.GauntletUI.Data;
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
            MapEscapeMenu.Insert(0, new EscapeMenuItemVM(new TextObject("Test Menu Button Insert"), o => {}, null, false));
            MapEscapeMenu.Add(new EscapeMenuItemVM(new TextObject("Test Menu Button 1"), o => {}, null, false));
            MapEscapeMenu.Add(new EscapeMenuItemVM(new TextObject("Test Menu Button 2"), o => {}, null, false));
            MapEscapeMenu.Add(new EscapeMenuItemVM(new TextObject("Test Menu Button 3"), o => {}, null, false));
        }
    }
}