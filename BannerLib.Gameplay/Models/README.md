# BannerLib.Gameplay.Models

A `GameModel` in Bannerlord essentially expresses an imeplementation of some mathematical systems for a particular feature of the game, replacing this implementation is a very simple way to change some core behaviour of the game or add in additional functionality. However this is arguably the most likely place for mods to create unintended conflicts and to outright break other mods. It's important to note that whilst `GameModels` are very powerful, they are also limited in their ability to handle more than one per "Base" type.

The simplest example of an implementation of a `GameModel` is the `DefaultGenericXpModel` which derives from `GenericXpModel` in the example below is a demonstration of how to replace this Model using BannerLib

```csharp
public class ExampleSubModule : MBSubModuleBase
{
    protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
    {
        // Only run this if we're in the campaign.
        if (!(game.GameType is Campaign)) return;
        // We replace the default implementation with our own defined below.
        gameStarterObject.Replace<DefaultGenericXpModel, MyCustomXpModel>();
        // That's it, now any time the game tries to calculate Xp it will use our model to do so.
    }
}

public class MyCustomXpModel : GenericXpModel
{
    public override float GetXpMultiplier(Hero hero)
    {
        // The DefaultGenericXpModel simply returns 1f
        // We instead will scale the xp based on the level of the player
        // The higher the level the more exp.
        return 1.1f * hero.Level;
    }
}
```