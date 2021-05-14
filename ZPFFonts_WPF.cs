#if WPF
using System.Windows.Media;
#endif

namespace ZPF.Fonts.WPF
{
   internal class IF_Dummy
   {
   }


   public static partial class IF
   {
#if WPF
      public static string GetFamilyName()
      {
         IF_Dummy o = new IF_Dummy();
         string aName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetAssembly(o.GetType()).Location);

         string st = $"/{aName};component/Fonts/#IconFont";

         return st;
      }

      private static System.Windows.Media.FontFamily _FontFamily = null;
      public static System.Windows.Media.FontFamily FontFamily
      {
         get
         {
            if (_FontFamily == null)
            {
               _FontFamily = new System.Windows.Media.FontFamily(new System.Uri("pack://application:,,,"), GetFamilyName());
            };

            return _FontFamily;
         }
      }

      private static System.Windows.Media.Typeface _Typeface = null;

      /// <summary>
      /// Creates a new System.Windows.Media.ImageSource of a specified FontAwesomeIcon and foreground System.Windows.Media.Brush.
      /// </summary>
      /// <param name="icon">The FontAwesome icon to be drawn.</param>
      /// <param name="foregroundBrush">The System.Windows.Media.Brush to be used as the foreground.</param>
      /// <returns>A new System.Windows.Media.ImageSource</returns>

      public static System.Windows.Media.ImageSource GetImageSource(int icon, System.Windows.Media.Brush foregroundBrush, double emSize = 100, double margin = 0)
      {
         string charIcon = char.ConvertFromUtf32(icon);

         if (_Typeface == null)
         {
            _Typeface = new System.Windows.Media.Typeface(FontFamily, System.Windows.FontStyles.Normal, System.Windows.FontWeights.Normal, System.Windows.FontStretches.Normal);
         };

         System.Windows.Media.DrawingVisual visual = new System.Windows.Media.DrawingVisual();

         using (System.Windows.Media.DrawingContext drawingContext = visual.RenderOpen())
         {
            FormattedText ft = new System.Windows.Media.FormattedText(
                   charIcon,
                   System.Globalization.CultureInfo.InvariantCulture,
                   System.Windows.FlowDirection.LeftToRight,
                   _Typeface, emSize - (2 * margin), foregroundBrush);

            ft.TextAlignment = System.Windows.TextAlignment.Center;

            drawingContext.DrawRectangle(null, new Pen(Brushes.Black, 0), new System.Windows.Rect(0, 0, emSize, emSize));
            drawingContext.DrawText(ft, new System.Windows.Point(emSize/2, margin));
         };

         return new System.Windows.Media.DrawingImage(visual.Drawing);
      }

      public static string GetContent(int icon)
      {
         return "" + (char)(icon);
      }

#endif
   }
}
