using System;
using TaleWorlds.InputSystem;

namespace BannerLib.Input
{
    /// <summary>
    /// Base type for all HotKey definitions to derive from.
    /// </summary>
    public abstract class HotKeyBase
    {
        internal int ID { get; set; }
        internal GameKey GameKey { get; set; }
        
        /// <summary>
        /// The unique (to your mod) Id for this hotkey.
        /// </summary>
        protected internal string IdName { get; }

        /// <summary>
        /// The default key for your HotKey, if this is not set in your constructor it will default to `Invalid`
        /// </summary>
        protected internal InputKey DefaultKey { get; protected set; } = InputKey.Invalid;
        
        /// <summary>
        /// The display name for your hotkey that will appear in the options menu.
        /// </summary>
        protected internal string DisplayName { get; protected set; }
        
        /// <summary>
        /// The description text that will appear in the options menu next to your hotkey.
        /// </summary>
        protected internal string Description { get; protected set; } = "No Description Set.";
        
        /// <summary>
        /// The Category in the options menu under which this hotkey will appear.
        /// <see cref="HotKeyManager.Categories"/>
        /// </summary>
        protected internal string Category { get; protected set; } =
            HotKeyManager.Categories[HotKeyCategory.Action];
        
        /// <summary>
        /// Called once on the frame a key was pressed.
        /// </summary>
        public event Action OnPressedEvent;
        /// <summary>
        /// Called once on the frame a key was released.
        /// </summary>
        public event Action OnReleasedEvent;
        /// <summary>
        /// Called once every frame a key remains down.
        /// </summary>
        public event Action IsDownEvent;
        
        /// <summary>
        /// Provide none, one or many functions which all must evaluate to true in order for the key to process input.
        /// This does not need to be set, and can be reset with <see cref="Predicate"/> = null;
        /// </summary>
        public Func<bool> Predicate { get; set; }
        
        /// <summary>
        /// Tells the input manager whether or not to process input for this key.
        /// Setting this infrequently is cheaper than using <see cref="Predicate"/> but it is less convenient.
        /// </summary>
        public bool IsEnabled { get; private set; } = true;
        
        /// <summary>
        /// The required constructor which has the bare minimum needed to register a key.
        /// </summary>
        /// <param name="idName">The (unique to your mod) id for your hotkey.</param>
        protected internal HotKeyBase(string idName)
        {
            IdName = idName;
            DisplayName = IdName;
        }

        /// <summary>
        /// Allows you to supply a HotKeyBase derived class wherever a GameKey might normally be used.
        /// </summary>
        /// <param name="hotkey"><see cref="HotKeyBase"/> to convert.</param>
        /// <returns>The <see cref="GameKey"/> stored internally.</returns>
        public static implicit operator GameKey(HotKeyBase hotkey) => hotkey.GameKey;
        
        /// <inheritdoc cref="OnPressedEvent"/>
        protected virtual void OnPressed() { }
        /// <inheritdoc cref="OnReleasedEvent"/>
        protected virtual void OnReleased() { }
        /// <inheritdoc cref="IsDownEvent"/>
        protected virtual void IsDown() { }

        internal bool ShouldExecute()
        {
            if (Predicate is null && IsEnabled) return true;
            return !(Predicate is null) && Predicate() && IsEnabled;
        }
        
        internal void OnPressedInternal()
        {
            OnPressedEvent?.Invoke();
            OnPressed();
        }

        internal void OnReleasedInternal()
        {
            OnReleasedEvent?.Invoke();
            OnReleased();
        }

        internal void IsDownInternal()
        {
            IsDownEvent?.Invoke();
            IsDown();
        }
    }
}