# XFCustomFonts
Xamarin.Forms test project demonstrating usage of custom fonts ...

## Current state
| platform | Label IF | Label MPF | Button<br />FontIcon | SkiaSharp |  
|----------|:--------:|:---------:|:---------------:|:----:|
| XF.UWP   |   OK     |   OK      |    OK    |  OK  | 
| XF.Android | OK     |   OK      |    OK    |  OK  |
| XF.iOS   |   OK     |   OK      |    OK    |  OK  |
| XF.MacOS |   OK     |   OK      |    OK    |  OK  |
| XF.WPF   |   OK     |   OK      |    KO    |  KO*1 |
  
   
### *1 XF.WPF SkiaSharp issue
Unable to cast object of type 'SkiaSharp.Views.Forms.SKCanvasViewRenderer' to type 'Xamarin.Forms.IRegisterable'.  
https://github.com/mono/SkiaSharp/issues/484  
https://github.com/mono/SkiaSharp/issues/486  
  
  
## How to build
Builds on Windows and MacOS with Visual Studio 2019 with the latest Xamarin, .NET Core and UWP installed.
