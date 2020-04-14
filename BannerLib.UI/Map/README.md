# BannerLib.UI.Map

Standardises map UI elements where additions/removals are common.

## MapEscapeMenu

Allows your mod to easily add/insert buttons to a standardised main menu.

```csharp
MapEscapeMenu.Add(new EscapeMenuItemVM(new TextObject("Test 2"), _ => { }, null, false));
MapEscapeMenu.Insert(0, new EscapeMenuItemVM(new TextObject("Test Insert Top"), _ => { }, null, false));
```

