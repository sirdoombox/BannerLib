![BannerLib Logo](https://staticdelivery.nexusmods.com/mods/3174/images/131/131-1586006962-1477512644.jpeg)
An attempt at making some common functionality standard, including some in-line XMLDocs to make development a bit easier and cleaning up some of the hideous constructor gore that a lot of the API seems to be made of. 
It's still early days so I'm just adding things as I go.

## Player Information

Currently it's not possible to use the launcher to re-order bannerlord mods, however you can manually set the load order of mods by running the `Bannerlord.exe` with the correct arguments, however that isn't ideal for most users so using a third party launcher that handles load order might be preferable in the short term.

## Mod Developer Information 

All you have to do is reference the assemblies you need (They should hopefully all remain entirely separate from one another) and add BannerLib as a dependency in your `SubModule.xml` file. Ensuring your users have this library load first is the most important, see the `Player Information` section for more details.

### Available Namespaces:

Here are the available base namespaces in the BannerLib project - (each of them being a separate DLL) - The links will take you to further documentation.

- [BannerLib.Gameplay](BannerLib.Gameplay) - Wraps various common gameplay features to make adding/removing/changing gameplay behaviour simpler.
- [BannerLib.Input](BannerLib.Input) - Simplifies and improves the input system and prevents mod collisions when multiple mods are registering hotkeys.
- [BannerLib.Misc](BannerLib.Misc) - Contains miscellaneous small helpers and documented wrappers for various API features.

## Build Setup

This information is only for people building the project from source.

- Create a file named "paths.csproj" in the main folder (same folder as the README.MD)
- Paste in the code below

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
<PropertyGroup>
	<GameBins>Path to the main bin/Win64_Shipping_Client folder</GameBins>
	<BuildPath>Path to the desired build folder</BuildPath>
</PropertyGroup>
</Project>
```
- Replace the "Path to ..." with your paths, remember to add "\\" at the end of the path!

Example:
```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
<PropertyGroup>
	<GameBins>G:\Steam\steamapps\common\Mount &amp; Blade II Bannerlord\bin\Win64_Shipping_Client\</GameBins>
	<BuildPath>G:\Steam\steamapps\common\Mount &amp; Blade II Bannerlord\Modules\BannerLib\bin\Win64_Shipping_Client\</BuildPath>
</PropertyGroup>
</Project>
```

