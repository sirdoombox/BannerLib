using System;
using TaleWorlds.InputSystem;

namespace BannerLib.Input
{
    /// <summary>
    /// The HotKey class that is used largely internally with some publicly exposed methods for functionality.
    /// </summary>
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
        
        /// <summary>
        /// This action will be called once on the frame that the key was pressed.
        /// </summary>
        /// <param name="onPressed">The action to bind to the event.</param>
        /// <returns>This, can be used to chain method calls.</returns>
        public HotKey WithOnPressedAction(Action onPressed)
        {
            OnPressed += onPressed;
            return this;
        }

        /// <summary>
        /// This action will be called once on the frame that the key was released.
        /// </summary>
        /// <param name="onReleased">The action to bind to the event.</param>
        /// <returns>This, can be used to chain method calls.</returns>
        public HotKey WithOnReleasedAction(Action onReleased)
        {
            OnReleased += onReleased;
            return this;
        }

        /// <summary>
        /// This action will be called once per frame that the key is down.
        /// </summary>
        /// <param name="isDown">The action to bind to the event.</param>
        /// <returns>This, can be used to chain method calls.</returns>
        public HotKey WithIsDownAction(Action isDown)
        {
            IsDown += isDown;
            return this;
        }

        /// <summary>
        /// A predicate for the key, the key will only process input when the predicate evaluates to true.
        /// </summary>
        /// <param name="predicate">The predicate for the key to process input.</param>
        /// <returns>This, can be used to chain method calls.</returns>
        public HotKey WithPredicate(Func<bool> predicate)
        {
            Predicate = predicate;
            return this;
        }

        /// <summary>
        /// Disable the hotkey.
        /// </summary>
        public void Disable()
        {
            IsEnabled = false;
        }

        /// <summary>
        /// Enable the hotkey.
        /// </summary>
        public void Enable()
        {
            IsEnabled = true;
        }
    }
}