using System;
using TaleWorlds.InputSystem;

namespace BannerLib.Input
{
    public class HotKey
    {
        internal int ID { get; }
        internal string HotKeyCategory { get; }
        internal string HotKeyName { get; }
        internal InputKey DefaultKey { get; }
        internal string HotKeyDisplayName { get; }
        internal string HotKeyDescription { get; }
        internal Action OnPressed { get; private set; }
        internal Action OnReleased { get; private set; }
        internal Action IsDown { get; private set; }
        
        internal Func<bool> Predicate { get; private set; }

        internal bool IsEnabled { get; private set; } = true;
        
        internal GameKey GameKey { get; set; }

        internal HotKey(int id, string hotKeyName, string hotKeyCategory, InputKey defaultKey, string hotKeyDisplayName, string hotKeyDescription)
        {
            ID = id;
            HotKeyName = hotKeyName;
            HotKeyCategory = hotKeyCategory;
            DefaultKey = defaultKey;
            HotKeyDescription = hotKeyDescription;
            HotKeyDisplayName = hotKeyDisplayName;
        }

        public HotKey WithOnPressedAction(Action onPressed)
        {
            OnPressed += onPressed;
            return this;
        }

        public HotKey WithOnReleasedAction(Action onReleased)
        {
            OnReleased += onReleased;
            return this;
        }

        public HotKey WithIsDownAction(Action isDown)
        {
            IsDown += isDown;
            return this;
        }

        public HotKey WithPredicate(Func<bool> predicate)
        {
            Predicate = predicate;
            return this;
        }

        public void Disable()
        {
            IsEnabled = false;
        }

        public void Enable()
        {
            IsEnabled = true;
        }
    }
}