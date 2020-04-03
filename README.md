# BannerLib
An attempt at making some common functionality standard, including some in-line XMLDocs to make development a bit easier and cleaning up some of the hideous constructor gore that a lot of the API seems to be made of. 
It's still early days so I'm just adding things as I go.

# Setup
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


## NameSpaces

- [BannerLib.Input](BannerLib.Input) - Simplifies, improves and prevents mod collisions in regards to player input.

