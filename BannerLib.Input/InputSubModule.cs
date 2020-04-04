using System.Collections.Generic;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade;
#pragma warning disable 1591

namespace BannerLib.Input
{
    public class InputSubModule : MBSubModuleBase
    {
        // TODO: Expand the system and make it more resistant to mod collisions.
        // TODO: Support the full suite of binding abilities.
        // TODO: Support localisation.
        internal static InputSubModule Instance { get; private set; }
        
        private readonly List<HotKey> m_hotKeys = new List<HotKey>(); 
        
        protected override void OnSubModuleLoad()
        {
            if (Instance == null) Instance = this;
        }

        internal void AddHotkeys(IEnumerable<HotKey> hotKeys)
        {
            m_hotKeys.AddRange(hotKeys);
        }

        protected override void OnApplicationTick(float dt)
        {
            foreach (var hotkey in m_hotKeys)
            {
                if (!hotkey.IsEnabled) continue;
                if (!(hotkey.Predicate is null) && !hotkey.Predicate()) continue;
                if (hotkey.GameKey.PrimaryKey.InputKey.IsDown())
                    hotkey.IsDown?.Invoke();
                if (hotkey.GameKey.PrimaryKey.InputKey.IsPressed())
                    hotkey.OnPressed?.Invoke();
                if (hotkey.GameKey.PrimaryKey.InputKey.IsReleased())
                    hotkey.OnReleased?.Invoke();
            }
        }
    }
}