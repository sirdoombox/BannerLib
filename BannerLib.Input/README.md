# Input

The `HotKeyManager` type and associated views and functionality inside of Bannerlord is incredibly convoluted to work with, there are lots of gotchas and having conflicts between different mods registering hotkeys with the same ID's or mod names is almost a certainty, so this simple wrapper around it was created that handles the finer details and handles input polling so the entire thing is event based.

## Usage

```csharp
public class MySubModule : MBSubModuleBase
{
    private bool m_campaignIsStarted;

    protected override void OnSubModuleLoad()
    {
        // first create a HotKey group for our mod.
        var hotkeys = HotKeys.Create("MySubModule");
        // Then add a hotkey to it.
        var menuKey = hotkeys.Add("ExamplShortCutKey",
            InputKey.Comma,
            HotKeyCategory.MenuShortcut,
            "Example Shortcut",
            "Displays a message confirming the key works.");
        // Only fire events for the input if the campaign is currently being played.
        menuKey.WithPredicate(() => m_campaignIsStarted);
        // On pressing the button display a message (InquiryBuilder is a part of BannerLib.Misc)
        menuKey.WithOnPressedAction(() => {
            InquiryBuilder.Create("You Pressed The Button!").BuildAndPublish(true);
        });
        // On releasing the button display another message.
        menuKey.WithOnReleasedAction(() => {
            InquiryBuilder.Create("You Released The Button!").BuildAndPublish(true);
        });
        // Build the keys up and register them with Bannerlord.
        hotkeys.Build();
    }

    protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
    {
        if (game.GameType is Campaign) m_campaignIsStarted = true;
    }
}
```

