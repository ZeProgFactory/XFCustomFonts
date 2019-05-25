using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.IO;
using System.Reflection;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFCustomFonts.Pages
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class FontPage : ContentPage
   {
      public FontPage()
      {
         InitializeComponent();

         labelIF.FontFamily = GetFontFamily(Device.RuntimePlatform);
         labelIF.Text = ZPFFonts.IF.GetContent(ZPFFonts.IF.ZPF);

         labelMPF.FontFamily = GetFontFamily(Device.RuntimePlatform, "MediaPlayerFont");
         labelMPF.Text = ZPFFonts.MPF.GetContent(ZPFFonts.MPF.Music);

         //Test 1
         //btnMPF.ImageSource = ImageSource.FromResource("XFCustomFonts.Images.Music.png", typeof(_HomePage));

         //Test 2
         //int width = 64;
         //int height = 64;
         //btnMPF.ImageSource = Render2ImageSource(width, height, (SKImageInfo info, SKCanvas canvas) =>
         //{
         //   canvas.Clear();

         //   SKPaint paint = new SKPaint
         //   {
         //      Style = SKPaintStyle.Fill,
         //      Color = Color.Black.ToSKColor(),
         //      IsAntialias = true,
         //   };

         //   paint.Typeface = SKTypeface.FromStream(GetStreamFromResources(typeof(SkiaPage), "XFCustomFonts.Fonts.MediaPlayerFont.ttf"));
         //   paint.TextSize = info.Width;

         //   canvas.DrawText(ZPFFonts.IF.GetContent(ZPFFonts.MPF.Music), 0, info.Height, paint);
         //});

         btnMPF.ImageSource = SkiaFontIcon(ZPFFonts.MPF.Music, 64);
      }

      // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - - 

      public static ImageSource SkiaFontIcon(string Icon, int size)
      {
         // Get Metrics
         var mainDisplayInfo = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo;

         switch( Device.RuntimePlatform)
         {
            case Device.UWP:
            case Device.iOS:
               // nope
               break;

            case Device.Android:
            default:
               size = (int)(size * mainDisplayInfo.Density);
               break;
         };

         return Render2ImageSource(size, size, (SKImageInfo info, SKCanvas canvas) =>
         {
            canvas.Clear();
            // canvas.Scale(2);

            SKPaint paint = new SKPaint
            {
               Style = SKPaintStyle.Fill,
               Color = Color.Black.ToSKColor(),
               IsAntialias = true,
            };

            paint.Typeface = SKTypeface.FromStream(GetStreamFromResources(typeof(SkiaPage), "XFCustomFonts.Fonts.MediaPlayerFont.ttf"));
            paint.TextSize = info.Width;

            canvas.DrawText(ZPFFonts.IF.GetContent(Icon), 0, info.Height, paint);
         });
      }

      public static ImageSource Render2ImageSource(int width, int height, Action<SKImageInfo, SKCanvas> action)
      {
         SKImageInfo info = new SKImageInfo(width, height);
         SKBitmap bitmap = new SKBitmap(info.Width, info.Height);
         SKCanvas canvas = new SKCanvas(bitmap);

         //Draw on canvas from stored commands DrawPath, etc.
         action(info, canvas);

         return (SKBitmapImageSource)bitmap;
      }

      public static Stream GetStreamFromResources(Type type, string resourceName)
      {
         var assembly = type.GetTypeInfo().Assembly;
         return assembly.GetManifestResourceStream(resourceName);
      }

      // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - - 

      /// <summary>
      /// </summary>
      /// <param name="RuntimePlatform"></param>
      /// <returns></returns>
      public static string GetFontFamily(string RuntimePlatform, string FontName = "IconFont")
      {
         switch (RuntimePlatform)
         {
            case "macOS":
            case "iOS":
               // Add the font file with Build Action: BundleResource, and
               // Update the Info.plist file(Fonts provided by application, or UIAppFonts, key)
               return $"{FontName}";

            case "Android":
               // add the font file to the Assets folder in the application project and set Build Action: AndroidAsset. 
               return $"{FontName}.ttf#{FontName}";

            case "WPF":
               // https://github.com/xamarin/Xamarin.Forms/pull/3225
               // add the font file to the /Fonts/ folder in the application project and set the Build Action:Resource - Do not copy.
               return $"/XFCustomFonts.WPF;component/Fonts/#{FontName}";

            default:
            case "UWP":
               // add the font file to the /Assets/Fonts/ folder in the application project and set the Build Action:Content.
               return $"Assets/Fonts/{FontName}.ttf#{FontName}";
         };
      }
   }
}