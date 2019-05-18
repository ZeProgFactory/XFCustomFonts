using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

         labelMPF.FontFamily = GetFontFamily(Device.RuntimePlatform,"MediaPlayerFont");
         labelMPF.Text = ZPFFonts.MPF.GetContent(ZPFFonts.MPF.Music);
      }

      /// <summary>
      /// OK: Android, WPF & UWP
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