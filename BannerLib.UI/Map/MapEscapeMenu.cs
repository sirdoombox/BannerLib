using System;
using System.Collections.Generic;
using System.Reflection;
using BannerLib.UI.Internal;
using SandBox.GauntletUI.Map;
using TaleWorlds.Core;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.GauntletUI;
using TaleWorlds.GauntletUI.Data;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.View.Missions;
using TaleWorlds.MountAndBlade.ViewModelCollection;

namespace BannerLib.UI.Map
{
    [OverrideView(typeof (SandBox.View.Map.MapEscapeMenu))]
    public class MapEscapeMenu : GauntletMapEscapeMenu
    {
        private static readonly List<(int, EscapeMenuItemVM)> m_addItems = new List<(int, EscapeMenuItemVM)>();
        
        public MapEscapeMenu(List<EscapeMenuItemVM> items) : base(items){}

        protected override void CreateLayout()
        {
            var menuItems =  this.GetNonPublicFieldValue<List<EscapeMenuItemVM>>("_menuItems", true);
            foreach (var (order, escapeMenuItem) in m_addItems)
            {
                if(order == -1)
                    menuItems.Add(escapeMenuItem);
                else 
                    menuItems.Insert(order, escapeMenuItem);
            }
            base.CreateLayout();
            // TIDY: This is a mess made primarily of magic.
            var menuMovie = this.GetNonPublicFieldValue<GauntletMovie>("_escapeMenuMovie", true);
            if (menuMovie == null) return;
            var listPanelParent = menuMovie.RootView.Target.Children[0];
            listPanelParent.SuggestedHeight = 800; // here
            var menuButtonsListPanel = listPanelParent.Children[0];
            menuButtonsListPanel.MarginBottom = 0;
            menuButtonsListPanel.MarginTop = 0;
            listPanelParent.RemoveAllChildren();
            var scrollBar = SetupScrollBarWidget(listPanelParent.Context);
            var scrollablePanel = new ScrollablePanel(menuMovie.RootView.Target.Context);
            var clipRectContainer = new Widget(scrollablePanel.Context);
            scrollablePanel.MarginBottom = 75;
            scrollablePanel.MarginTop = 100;
            scrollablePanel.HeightSizePolicy = SizePolicy.StretchToParent;
            scrollablePanel.WidthSizePolicy = SizePolicy.StretchToParent;
            scrollablePanel.AutoHideScrollBars = true;
            clipRectContainer.HeightSizePolicy = SizePolicy.StretchToParent;
            clipRectContainer.WidthSizePolicy = SizePolicy.StretchToParent;
            clipRectContainer.ClipContents = true;
            scrollablePanel.InnerPanel = menuButtonsListPanel;
            scrollablePanel.ClipRect = clipRectContainer;
            scrollablePanel.VerticalScrollbar = scrollBar;
            listPanelParent.AddChild(scrollBar);
            listPanelParent.AddChild(scrollablePanel);
            scrollablePanel.AddChild(clipRectContainer);
            clipRectContainer.AddChild(menuButtonsListPanel);
        }

        private ScrollbarWidget SetupScrollBarWidget(UIContext ctx)
        {
            var scrollBar = new ScrollbarWidget(ctx);
            var handle = SetupScrollBarHandle(scrollBar.Context);
            var scrollbarBackground = SetupScrollBarBackground(scrollBar.Context);
            scrollBar.Handle = handle;
            scrollBar.WidthSizePolicy = SizePolicy.Fixed;
            scrollBar.HeightSizePolicy = SizePolicy.StretchToParent;
            scrollBar.HorizontalAlignment = HorizontalAlignment.Right;
            scrollBar.MarginRight = 123f;
            scrollBar.MarginBottom = 100;
            scrollBar.MarginTop = 100;
            scrollBar.AlignmentAxis = AlignmentAxis.Vertical;
            scrollBar.MinValue = 0;
            scrollBar.MaxValue = 100;
            scrollBar.AddChild(scrollbarBackground);
            scrollBar.AddChild(handle);
            return scrollBar;
        }

        private ImageWidget SetupScrollBarHandle(UIContext ctx)
        {
            var handle = new ImageWidget(ctx);
            handle.WidthSizePolicy = handle.HeightSizePolicy = SizePolicy.Fixed;
            handle.Brush = UIResourceManager.BrushFactory.GetBrush("FaceGen.Scrollbar.Handle");
            handle.Brush.Color = Color.White;
            handle.Brush.AlphaFactor = 0.4f;
            handle.HorizontalAlignment = HorizontalAlignment.Center;
            handle.SuggestedHeight = 10;
            handle.SuggestedWidth = 8;
            return handle;
        }

        private Widget SetupScrollBarBackground(UIContext ctx)
        {
            var background = new Widget(ctx);
            background.WidthSizePolicy = SizePolicy.Fixed;
            background.HeightSizePolicy = SizePolicy.StretchToParent;
            background.HorizontalAlignment = HorizontalAlignment.Center;
            background.SuggestedWidth = 4;
            background.Sprite = UIResourceManager.SpriteData.GetSprite("BlankWhiteSquare_9");
            background.Brush.Color = Color.White;
            background.Brush.AlphaFactor = 0.2f;
            return background;
        }

        public static void Add(EscapeMenuItemVM menuItem)
        {
            if(menuItem is null) throw new ArgumentNullException(nameof(menuItem));
            m_addItems.Add((-1, menuItem));
        }

        public static void Insert(int position, EscapeMenuItemVM menuItem)
        {
            if(menuItem is null) throw new ArgumentNullException(nameof(menuItem));
            if(position < 0) throw new ArgumentOutOfRangeException(nameof(menuItem));
            m_addItems.Add((position,menuItem));
        }
    }
}