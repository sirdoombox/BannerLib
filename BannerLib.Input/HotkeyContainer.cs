using TaleWorlds.InputSystem;

namespace BannerLib.Input
{
    public struct HotKeyContainer
    {
        internal int ID { get; }
        internal string HotKeyName { get; }
        internal string HotKeyCategory { get; }
        internal InputKey HotKey { get; }
            
        internal string HotKeyDisplayName { get; }
            
        internal string HotKeyDescription { get; }

        internal HotKeyContainer(int id, string hotKeyName, string hotKeyCategory, InputKey hotKey, string hotKeyDisplayName, string hotKeyDescription)
        {
            ID = id;
            HotKeyName = hotKeyName;
            HotKeyCategory = hotKeyCategory;
            HotKey = hotKey;
            HotKeyDescription = hotKeyDescription;
            HotKeyDisplayName = hotKeyDisplayName;
        }
    }
}