using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.Engine;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;

namespace BannerLib.Input
{
    /// <summary>
    /// Describes a single HotKey group to which you can add individual HotKeyManager before building.
    /// </summary>
    public class HotKeyManager
    {
        /// <summary>
        /// The available categories in the main menu for your hotkey to appear under.
        /// </summary>
        public static readonly IReadOnlyDictionary<HotKeyCategory, string> Categories = 
            new Dictionary<HotKeyCategory, string>
            {
                {HotKeyCategory.Action, nameof(GameKeyMainCategories.ActionCategory)},
                {HotKeyCategory.Chat, nameof(GameKeyMainCategories.ChatCategory)},
                {HotKeyCategory.CampaignMap,nameof(GameKeyMainCategories.CampaignMapCategory)},
                {HotKeyCategory.MenuShortcut, nameof(GameKeyMainCategories.MenuShortcutCategory)},
                {HotKeyCategory.OrderMenu, nameof(GameKeyMainCategories.OrderMenuCategory)}
            };
        
        private int m_currentId;
        private readonly string m_subModName;
        private readonly List<HotKeyBase> m_hotKeys = new List<HotKeyBase>();

        private HotKeyManager(int startId, string subModName)
        {
            m_subModName = subModName;
            m_currentId = startId;
        }
        
        /// <summary>
        /// Create a new HotKey group for your mod.
        /// </summary>
        /// <param name="modName">The name of your mod.</param>
        /// <returns>A HotKeyManager object for you to start adding new HotKeyManager to.</returns>
        /// <exception cref="ArgumentException">Thrown if a mod with the same name has already begun registering hotkeys.</exception>
        public static HotKeyManager Create(string modName)
        {
            var doesModAlreadyHaveRegisteredKeys = TaleWorlds.InputSystem.HotKeyManager.GetAllCategories()
                .Any(x => string.Equals(x.GameKeyCategoryId, modName, StringComparison.OrdinalIgnoreCase));
            if (doesModAlreadyHaveRegisteredKeys)
                throw new ArgumentException("Hotkeys For Mod With This Name Already Exists.", nameof(modName));
            var idMax = 0;
            foreach (var category in TaleWorlds.InputSystem.HotKeyManager.GetAllCategories())
            {
                foreach (var gamekey in category.RegisteredGameKeys)
                {
                    if(gamekey is null) continue;
                    if (gamekey.Id > idMax)
                        idMax = gamekey.Id + 1;
                }
            }
            // There's a sneaky extra key in here for unclear reasons.
            if (idMax == 69) idMax++;
            return new HotKeyManager(idMax,modName);
        }
        
        /// <summary>
        /// Adds a hotkey to the manager ready for building.
        /// </summary>
        /// <param name="hotkey">The <see cref="HotKeyBase"/> to add.</param>
        /// <typeparam name="T">The <see cref="HotKeyBase"/> derived type to add.</typeparam>
        /// <returns>The provided <see cref="HotKeyBase"/> (now initialised)</returns>
        /// <exception cref="ArgumentException">Thrown when a hotkey with the same IdName exists.</exception>
        public T Add<T>(T hotkey) where T : HotKeyBase
        {
            if(m_hotKeys.Any(x => string.Equals(x.IdName, hotkey.IdName, StringComparison.OrdinalIgnoreCase))) 
                throw new ArgumentException($"A hotkey called {hotkey.IdName} already exists", nameof(hotkey));
            m_hotKeys.Add(hotkey);
            hotkey.ID = m_currentId;
            m_currentId++;
            return hotkey;
        }
        
        /// <summary>
        /// Adds a hotkey to he manager ready for building.
        /// </summary>
        /// <typeparam name="T">The <see cref="HotKeyBase"/> derived type to add.</typeparam>
        /// <returns>A new instance of <seealso cref="HotKeyBase"/></returns>
        public T Add<T>() where T : HotKeyBase, new() => Add(new T());
        
        /// <summary>
        /// Builds up the hotkeys and registers them with Bannerlord.
        /// </summary>
        /// <returns>Returns all the hotkeys that were built up.</returns>
        public IReadOnlyList<HotKeyBase> Build()
        {
            var hotKeyCategoryContainer = new HotKeyCategoryContainer(m_subModName, m_currentId + 1, m_hotKeys);
            TaleWorlds.InputSystem.HotKeyManager.Initialize("Bannerlord", Utilities.GetConfigsPath() + "BannerlordGameKeys.xml", 
                new List<GameKeyContext> { hotKeyCategoryContainer }, true);
            var keys = hotKeyCategoryContainer.RegisteredGameKeys;
            foreach (var hotkey in m_hotKeys)
            {
                foreach (var gameKey in keys)
                {
                    if (gameKey is null) continue;
                    if (string.Equals(gameKey.StringId, hotkey.IdName, StringComparison.OrdinalIgnoreCase))
                        hotkey.GameKey = gameKey;
                }
            }
            InputSubModule.Instance.AddHotkeys(m_hotKeys);
            return m_hotKeys;
        }
    }
}