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
   public partial class _HomePage : ContentPage
   {
      public _HomePage()
      {
         InitializeComponent();
      }

      private void Button_FontPage_Clicked(object sender, EventArgs e)
      {
         Navigation.PushAsync(new FontPage());
      }

      private void Button_SkiaPage_Clicked(object sender, EventArgs e)
      {

      }
   }
}