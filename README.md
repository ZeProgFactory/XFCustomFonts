﻿# XFCustomFonts
Xamarin.Forms test project demonstrating usage of custom fonts ...

Update to Xamarin.Forms 4.2.0.709249 (not tested yet)

## Current state (Xamarin.Forms 4.0.0.540366)
| platform | Label IF | Label MPF | Button<br />FontIcon | SkiaSharp |  
|----------|:--------:|:---------:|:---------------:|:----:|
| XF.UWP   |   OK     |   OK      |    OK    |  OK  | 
| XF.Android | OK     |   OK      |    OK    |  OK  |
| XF.iOS   |   OK     |   OK      |    OK    |  OK  |
| XF.MacOS |   OK     |   OK      |    OK    |  OK  |
| XF.WPF   |   OK     |   OK      |    KO    |  KO*1|
  
IF = IconFont / MPF = MediaPlayerFont
   
## Xamarin.Forms 4.0.0.482894
black screen on XF.WPF

## Xamarin.Forms 3.6.0.344457, 4.0.0.425677, 4.0.0.497661
| platform | Label IF | Label MPF | Button<br />FontIcon | SkiaSharp |  
|----------|:--------:|:---------:|:---------------:|:----:|
| XF.UWP   |   OK     |   OK      |    OK    |  OK  | 
| XF.Android | OK     |   OK      |    OK    |  OK  |
| XF.iOS   |   OK     |   OK      |    OK    |  OK  |
| XF.MacOS |   OK     |   OK      |    OK    |  OK  |
| XF.WPF   |   OK     |   OK      |    KO    |  KO*1 |
  
IF = IconFont / MPF = MediaPlayerFont
   
### *1 XF.WPF SkiaSharp issue
Unable to cast object of type 'SkiaSharp.Views.Forms.SKCanvasViewRenderer' to type 'Xamarin.Forms.IRegisterable'.  
https://github.com/mono/SkiaSharp/issues/484  
https://github.com/mono/SkiaSharp/issues/486  
  

# HowTO

## Android

    <AndroidAsset Include="Assets\MediaPlayerFont.ttf" />


## iOS

    <BundleResource Include="Resources\Fonts\MediaPlayerFont.ttf" />

### info.plist

	<key>UIAppFonts</key>
	<array>
		<string>Fonts/IconFont.ttf</string>
		<string>Fonts/MediaPlayerFont.ttf</string>
	</array>
	<key>ATSApplicationFontsPath</key>
	<string>Fonts</string>


## MacOS

    <BundleResource Include="Resources\Fonts\MediaPlayerFont.ttf" />

### info.plist

	<key>UIAppFonts</key>
	<array>
		<string>Fonts/IconFont.ttf</string>
		<string>Fonts/MediaPlayerFont.ttf</string>
	</array>
	<key>ATSApplicationFontsPath</key>
	<string>Fonts</string>


## UWP

    <Content Include="Assets\Fonts\MediaPlayerFont.ttf" />
    
    
# How to build
Builds on Windows and MacOS with Visual Studio 2019 with the latest Xamarin, .NET Core and UWP installed.
