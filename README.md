# XFCustomFonts
Xamarin.Forms test project demonstrating usage of custom fonts ...

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
  
  
## How to build
Builds on Windows and MacOS with Visual Studio 2019 with the latest Xamarin, .NET Core and UWP installed.
