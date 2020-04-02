using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.Engine;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace BannerLib.Input
{
    public class HotKeys
    {
        private static readonly IReadOnlyDictionary<HotKeyCategory, string> m_categories = 
            new Dictionary<HotKeyCategory, string>
            {
                {HotKeyCategory.Action, nameof(GameKeyMainCategories.ActionCategory)},
                {HotKeyCategory.Chat, nameof(GameKeyMainCategories.ChatCategory)},
                {HotKeyCategory.CampaignMap,nameof(GameKeyMainCategories.CampaignMapCategory)},
                {HotKeyCategory.MenuShortcut, nameof(GameKeyMainCategories.MenuShortcutCategory)},
                {HotKeyCategory.OrderMenu, nameof(GameKeyMainCategories.OrderMenuCategory)}
            };
        
        private readonly int m_startId;
        private int m_currentId;
        private readonly string m_subModName;
        private readonly List<HotKeyContainer> m_hotKeys = new List<HotKeyContainer>();
        
        internal HotKeys(int startId, string subModName)
        {
            m_startId = startId;
            m_subModName = subModName;
            m_currentId = startId;
        }
        
        public static HotKeys Create(string modName, bool throwExceptionOnInvalidCategoryName = true)
        {
            var doesModAlreadyHaveRegisteredKeys = HotKeyManager.GetAllCategories()
                .Any(x => string.Equals(x.GameKeyCategoryId, modName, StringComparison.OrdinalIgnoreCase));
            if (doesModAlreadyHaveRegisteredKeys)
            {
                
                if (throwExceptionOnInvalidCategoryName)
                    throw new ArgumentException("Mod With This Name Already Exists.", nameof(modName));
                return null;
            }
            var idMax = 0;
            foreach (var category in HotKeyManager.GetAllCategories())
            {
                foreach (var gamekey in category.RegisteredGameKeys)
                {
                    if(gamekey is null) continue;
                    if (gamekey.Id > idMax)
                        idMax = gamekey.Id + 1;
                }
            }

            if (idMax == 69) idMax++;
            return new HotKeys(idMax,modName);
        }

        public HotKeys Add(string hotKeyName, InputKey defaultKey, HotKeyCategory category, string hotkeyDisplayName = "", string description = "")
        {
            if(m_hotKeys.Any(x => string.Equals(x.HotKeyName, hotKeyName, StringComparison.OrdinalIgnoreCase))) 
                throw new ArgumentException($"A hotkey called {hotKeyName} already exists", nameof(hotKeyName));
            m_hotKeys.Add(
                new HotKeyContainer(
                    m_currentId, 
                    hotKeyName, 
                    m_categories[category], 
                    defaultKey, 
                    string.IsNullOrWhiteSpace(hotkeyDisplayName) ? hotKeyName : hotkeyDisplayName, 
                    description));
            m_currentId++;
            return this;
        }

        public MBReadOnlyList<GameKey> Build()
        {
            var hotKeyCategoryContainer = new HotKeyCategoryContainer(m_subModName, m_currentId + 1, m_hotKeys);
            HotKeyManager.Initialize("Bannerlord", Utilities.GetConfigsPath() + "BannerlordGameKeys.xml", 
                new List<GameKeyContext> { hotKeyCategoryContainer }, true);
            return hotKeyCategoryContainer.RegisteredGameKeys;
        }
    }
}