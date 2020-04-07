using System.Collections.Generic;
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
        
        private readonly List<HotKeyBase> m_hotKeys = new List<HotKeyBase>();
        
        protected override void OnSubModuleLoad()
        {
            if (Instance == null) Instance = this;
        }

        internal void AddHotkeys(IEnumerable<HotKeyBase> hotKeys)
        {
            m_hotKeys.AddRange(hotKeys);
        }

        protected override void OnApplicationTick(float dt)
        {
            foreach (var hotkey in m_hotKeys)
            {
                if (!hotkey.ShouldExecute()) continue;
                if (hotkey.GameKey.PrimaryKey.InputKey.IsDown())
                    hotkey.IsDownInternal();
                if (hotkey.GameKey.PrimaryKey.InputKey.IsPressed())
                    hotkey.OnPressedInternal();
                if (hotkey.GameKey.PrimaryKey.InputKey.IsReleased())
                    hotkey.OnReleasedInternal();
            }
        }
    }
}