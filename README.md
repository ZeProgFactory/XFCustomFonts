# XFCustomFonts
Xamarin.Forms test project demonstrating usage of custom fonts ...

## Current state
| platform | Label IF | Label MPF | SkiaSharp |  
|----------|:--------:|:---------:|:----:|
| XF.UWP   |   OK     |   OK      |  OK  | 
| XF.Android | OK     |   OK      |  OK  |
| XF.iOS   |   OK     |    ?      |  OK  |
| XF.MacOS |   OK     |   OK      |  OK  |
| XF.WPF   |   OK     |   OK      |  KO* |
  
   
### *XF.WPF SkiaSharp issue
https://github.com/mono/SkiaSharp/issues/484
https://github.com/mono/SkiaSharp/issues/486  
  
  
## How to build
Builds on Windows and MacOS with Visual Studio 2019 with the latest Xamarin, .NET Core and UWP installed.
