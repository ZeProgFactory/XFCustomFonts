#if WPF
using System.Windows.Media;
#endif

#if XF
#endif

using System;
using ZPF;


//namespace ZPF
//{
//   public class Fonts : BaseViewModel
//   {
//      // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  -

//      static FontViewModel _Current = null;

//      public static FontViewModel Current
//      {
//         get
//         {
//            if (_Current == null)
//            {
//               _Current = new FontViewModel();
//            };

//            return _Current;
//         }

//         set
//         {
//            _Current = value;
//         }
//      }

//      // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  -

//      public static string Add_New { get => "" + (char)0xE900; }
//      public static string Analytics { get => "" + (char)0xE901; }

//      // - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  - -  -

//   }

//}


namespace ZPF.Fonts
{
#if WPF
   class IF_Dummy { }
#endif

   ///<summary>
   /// Usage:
   /// 
   /// WPF.APP.XAML:
   ///      <!--http://www.alteridem.net/2014/02/24/custom-fonts-in-wpf-applications/-->
   ///      <Style x:Key="IconFont">
   ///         <Setter Property = "TextElement.FontFamily" Value="/ZPF.WPF.Compos;Component/Fonts/#IconFont" />
   ///         <!--<Setter Property = "TextElement.FontFamily" Value="//application:,,,/Fonts/#IconFont" />-->
   ///      </Style>
   /// 
   /// WPF.Page.XAML:
   ///    xmlns:ZPFFonts="clr-namespace:ZPF.Fonts;assembly=ZPFLib_WPF"
   ///    
   ///    ...
   /// 
   ///    <TextBlock Style = "{StaticResource IconFont}" FontSize="60" Text="{x:Static ZPFFonts:IF.Inventory2}" />
   ///    
   /// 
   /// 
   ///    <Label Content="&#xE901;" FontSize="24" FontFamily="/ZPF.Fonts;component/Fonts/#IconFont" />
   ///</summary>
#if XF
   // https://medium.com/@nirinchev/using-icon-fonts-with-xamarin-forms-16da98c98e05
   public interface ITabPage
   {
      string TabIcon { get; }

      string SelectedTabIcon { get; }
   }

#endif

#if XF || __WASM__ || __UWP__
   public static class IF
#endif
#if WPF
   public sealed class IF
#endif
   {
      //public static System.Windows.Media.FontFamily FontFamily = new System.Windows.Media.FontFamily(new Uri("pack://application:,,,"), "/ZPF.Fonts;component/Fonts/#IconFont");

      //public static Image DrawText(string text, float FontSize = 12)
      //{
      //   System.Windows.Media.FontFamily FontFamily2 = new System.Windows.Media.FontFamily(new System.Uri("pack://application:,,,"), GetFamilyName());

      //   Color backColor = Xamarin.Forms.Color.Transparent;
      //   Color textColor = Xamarin.Forms.Color.Black;
      //   FontFamily FontFamily = new System.Drawing.FontFamily(GetFamilyName());

      //   Font font = new Font(FontFamily, FontSize);

      //   return DrawText(text, font, textColor, backColor);
      //}

      //public static Image DrawText(string text, Font font, Color textColor, Color backColor)
      //{
      //   //first, create a dummy bitmap just to get a graphics object
      //   Image img = new Bitmap(1, 1);
      //   Graphics drawing = Graphics.FromImage(img);

      //   //measure the string to see how big the image needs to be
      //   SizeF textSize = drawing.MeasureString(text, font);

      //   //free up the dummy image and old graphics object
      //   img.Dispose();
      //   drawing.Dispose();

      //   //create a new image of the right size
      //   img = new Bitmap((int)textSize.Width, (int)textSize.Height);

      //   drawing = Graphics.FromImage(img);

      //   //paint the background
      //   drawing.Clear(backColor);

      //   //create a brush for the text
      //   Brush textBrush = new SolidBrush(textColor);

      //   drawing.DrawString(text, font, textBrush, 0, 0);

      //   drawing.Save();

      //   textBrush.Dispose();
      //   drawing.Dispose();

      //   return img;
      //}

      //public Bitmap ConvertTextToImage(string txt, string fontname, int fontsize, Color bgcolor, Color fcolor, int width, int Height)
      //{
      //   Bitmap bmp = new Bitmap(width, Height);

      //   using (Graphics graphics = Graphics.FromImage(bmp))
      //   {

      //      Font font = new Font(fontname, fontsize);
      //      graphics.FillRectangle(new SolidBrush(bgcolor), 0, 0, bmp.Width, bmp.Height);
      //      graphics.DrawString(txt, font, new SolidBrush(fcolor), 0, 0);
      //      graphics.Flush();
      //      font.Dispose();
      //      graphics.Dispose();
      //   }

      //   return bmp;
      //}

#if XF || __WASM__

      public static string GetContent(int icon)
      {
         return "" + (char)(icon);
      }

      public static string GetContent(string icon)
      {
         return icon;
      }

      public static string GetFontFamily(string RuntimePlatform)
      {
         // SKTypeface.FromStream(XFHelper.GetStreamFromResources(typeof(PageEx), "ZPF_Basics_XF.Images.IconFont.ttf"));

         switch (RuntimePlatform)
         {
            case "macOS":
            case "iOS":
               // Add the font file with Build Action: BundleResource, and
               // Update the Info.plist file(Fonts provided by application, or UIAppFonts, key)
               return "IconFont";

            case "Android":
               // add the font file to the Assets folder in the application project and set Build Action: AndroidAsset. 
               return "IconFont.ttf#IconFont";

            case "WPF":
               // https://github.com/xamarin/Xamarin.Forms/pull/3225
               // add the font file to the /Fonts/ folder in the application project and set the Build Action:Resource - Do not copy.
               //_LabelImage.FontFamily = $"component/Fonts/#IconFont"; break;
               //_LabelImage.FontFamily = $"/Assets/IconFont.ttf#IconFont";
               //return "/StockAPPro.WPF;component/Assets/#IconFont";
               return "/ZPF_Basics_XF;component/Fonts/#IconFont";

            default:
            case "UWP":
               // add the font file to the /Assets/Fonts/ folder in the application project and set the Build Action:Content.
               //return "Assets/Fonts/IconFont.ttf#IconFont";
               return "/ZPF_Basics_XF;component/Images/IconFont.ttf#IconFont";
         };
      }
#endif

#if WPF
      public static string GetFamilyName()
      {
         IF_Dummy o = new IF_Dummy();
         string aName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetAssembly(o.GetType()).Location);

         //string st = $"/{aName};component/Fonts/#IconFont";
         string st = $"./#IconFont";

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
      public static System.Windows.Media.ImageSource GetImageSource(string icon, System.Windows.Media.Brush foregroundBrush, double emSize = 100, double margin = 0)
      {
         return GetImageSource(icon[0], foregroundBrush, emSize, margin);
      }

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
            drawingContext.DrawText(ft, new System.Windows.Point(emSize / 2, margin));
         };

         return new System.Windows.Media.DrawingImage(visual.Drawing);
      }

      public static string GetContent(int icon)
      {
         return "" + (char)(icon);
      }

#endif

      //public static string Add_New = "\ue900";
public static string Add_New { get => ""+(char)0xE900; }
public static string Analytics { get => ""+(char)0xE901; }
public static string Annoyed_WF { get => ""+(char)0xE902; }
public static string Archive { get => ""+(char)0xE903; }
public static string Arrow_Down { get => ""+(char)0xE904; }
public static string Arrow_Left { get => ""+(char)0xE905; }
public static string Arrow_Right { get => ""+(char)0xE906; }
public static string Arrow_Up { get => ""+(char)0xE907; }
public static string ArrowHead_Down { get => ""+(char)0xE908; }
public static string ArrowHead_Left { get => ""+(char)0xE909; }
public static string ArrowHead_Right { get => ""+(char)0xE90A; }
public static string ArrowHead_Up { get => ""+(char)0xE90B; }
public static string Barcode_01 { get => ""+(char)0xE90C; }
public static string Beaker { get => ""+(char)0xE90D; }
public static string Bookmark { get => ""+(char)0xE90E; }
public static string Bulb_02 { get => ""+(char)0xE90F; }
public static string Bulb_03 { get => ""+(char)0xE910; }
public static string Calendar_01 { get => ""+(char)0xE911; }
public static string CalToday { get => ""+(char)0xE912; }
public static string Camera_01_WF { get => ""+(char)0xE913; }
public static string Car_01 { get => ""+(char)0xE914; }
public static string Check_Mark_01 { get => ""+(char)0xE915; }
public static string Circle_Info_02 { get => ""+(char)0xE916; }
public static string Circle { get => ""+(char)0xE917; }
public static string Circle_01 { get => ""+(char)0xE918; }
public static string CircledCheckBox_01 { get => ""+(char)0xE919; }
public static string Clean_Brush { get => ""+(char)0xE91A; }
public static string Clipboard1_WF { get => ""+(char)0xE91B; }
public static string Clock_WF { get => ""+(char)0xE91C; }
public static string Close { get => ""+(char)0xE91D; }
public static string Cloud_Download_WF { get => ""+(char)0xE91E; }
public static string Cloud_Upload_W { get => ""+(char)0xE91F; }
public static string Contact { get => ""+(char)0xE920; }
public static string Contacts_Info { get => ""+(char)0xE921; }
public static string Contacts_Directory_01 { get => ""+(char)0xE922; }
public static string Copy_WF { get => ""+(char)0xE923; }
public static string Counting_Machine { get => ""+(char)0xE924; }
public static string Credit_Card1_WF { get => ""+(char)0xE925; }
public static string Customer  { get => ""+(char)0xE926; }
public static string Data_Sync_WF { get => ""+(char)0xE927; }
public static string Database_Connection_WF { get => ""+(char)0xE928; }
public static string Data_Delete { get => ""+(char)0xE929; }
public static string Data_Down { get => ""+(char)0xE92A; }
public static string Data_Edit { get => ""+(char)0xE92B; }
public static string Data_Export { get => ""+(char)0xE92C; }
public static string Data_Files { get => ""+(char)0xE92D; }
public static string DataFiles_WF { get => ""+(char)0xE92E; }
public static string Data_Import { get => ""+(char)0xE92F; }
public static string Data_Information { get => ""+(char)0xE930; }
public static string Delete { get => ""+(char)0xE931; }
public static string Delivery_packages_on_a_trolley { get => ""+(char)0xE932; }
public static string Device_Calculator { get => ""+(char)0xE933; }
public static string Dialog_Box_About { get => ""+(char)0xE934; }
public static string Digital_Gauge { get => ""+(char)0xE935; }
public static string Direction_North_Circle { get => ""+(char)0xE936; }
public static string Direction_North_WF { get => ""+(char)0xE937; }
public static string Distance { get => ""+(char)0xE938; }
public static string Distance_Black { get => ""+(char)0xE939; }
public static string Document_Check { get => ""+(char)0xE93A; }
public static string Document_Music_02 { get => ""+(char)0xE93B; }
public static string Document_WF { get => ""+(char)0xE93C; }
public static string Document_WF_Landscape { get => ""+(char)0xE93D; }
public static string Dots { get => ""+(char)0xE93E; }
public static string Drag_01_WF { get => ""+(char)0xE93F; }
public static string Empty { get => ""+(char)0xE940; }
public static string Entry_01_WF { get => ""+(char)0xE941; }
public static string Excel_Online { get => ""+(char)0xE942; }
public static string Exit_03 { get => ""+(char)0xE943; }
public static string Exit_WF { get => ""+(char)0xE944; }
public static string Expand_Collapse_WF { get => ""+(char)0xE945; }
public static string Export_01_WF { get => ""+(char)0xE946; }
public static string Export_WF { get => ""+(char)0xE947; }
public static string File_Format_PDF { get => ""+(char)0xE948; }
public static string Filter_Delete { get => ""+(char)0xE949; }
public static string Filter_Standard { get => ""+(char)0xE94A; }
public static string Flame_WF { get => ""+(char)0xE94B; }
public static string Folder_03 { get => ""+(char)0xE94C; }
public static string Folder_Open_03 { get => ""+(char)0xE94D; }
public static string FolderTree { get => ""+(char)0xE94E; }
public static string Foot_print_02 { get => ""+(char)0xE94F; }
public static string Gantt_WF  { get => ""+(char)0xE950; }
public static string Gas_Power { get => ""+(char)0xE951; }
public static string Happy_01_WF { get => ""+(char)0xE952; }
public static string Help { get => ""+(char)0xE953; }
public static string Hide1_WF { get => ""+(char)0xE954; }
public static string House { get => ""+(char)0xE955; }
public static string Import_01_WF { get => ""+(char)0xE956; }
public static string Imports_WF { get => ""+(char)0xE957; }
public static string Inventory { get => ""+(char)0xE958; }
public static string Inventory_2col { get => ""+(char)0xE959; }
public static string Inventory2 { get => ""+(char)0xE95A; }
public static string Item_New { get => ""+(char)0xE95B; }
public static string Loading_01 { get => ""+(char)0xE95C; }
public static string Login_01 { get => ""+(char)0xE95D; }
public static string Login2_WF { get => ""+(char)0xE95E; }
public static string Magic_Wand { get => ""+(char)0xE95F; }
public static string Mail_03 { get => ""+(char)0xE960; }
public static string Man_02 { get => ""+(char)0xE961; }
public static string Map_Location { get => ""+(char)0xE962; }
public static string Maps_04 { get => ""+(char)0xE963; }
public static string Media_Backward { get => ""+(char)0xE964; }
public static string Media_First { get => ""+(char)0xE965; }
public static string Media_Last { get => ""+(char)0xE966; }
public static string Media_Next { get => ""+(char)0xE967; }
public static string Media_Pause { get => ""+(char)0xE968; }
public static string Media_Previous { get => ""+(char)0xE969; }
public static string Media_Fast_Forward { get => ""+(char)0xE96A; }
public static string Media_Play2_WF { get => ""+(char)0xE96B; }
public static string Media_Play_01 { get => ""+(char)0xE96C; }
public static string Message_Mail_WF { get => ""+(char)0xE96D; }
public static string Messages_Information_01 { get => ""+(char)0xE96E; }
public static string Message_Warning { get => ""+(char)0xE96F; }
public static string Minus { get => ""+(char)0xE970; }
public static string Mobile_Phone { get => ""+(char)0xE971; }
public static string Mouse_Drag { get => ""+(char)0xE972; }
public static string Msg_sent_WF { get => ""+(char)0xE973; }
public static string Music { get => ""+(char)0xE974; }
public static string Navigation_Down_Right { get => ""+(char)0xE975; }
public static string Navigation_Left { get => ""+(char)0xE976; }
public static string Navigation_Right { get => ""+(char)0xE977; }
public static string Navigation_Up_Right { get => ""+(char)0xE978; }
public static string Network_Drives { get => ""+(char)0xE979; }
public static string Note_Memo_01 { get => ""+(char)0xE97A; }
public static string NumKeypad { get => ""+(char)0xE97B; }
public static string Open { get => ""+(char)0xE97C; }
public static string Parcel { get => ""+(char)0xE97D; }
public static string People { get => ""+(char)0xE97E; }
public static string Picture { get => ""+(char)0xE97F; }
public static string Pin { get => ""+(char)0xE980; }
public static string Post_it { get => ""+(char)0xE981; }
public static string Preview { get => ""+(char)0xE982; }
public static string Previous { get => ""+(char)0xE983; }
public static string Print_01 { get => ""+(char)0xE984; }
public static string Product_Box_03_WF { get => ""+(char)0xE985; }
public static string Project_Plan_02_WF { get => ""+(char)0xE986; }
public static string QRCode1_WF { get => ""+(char)0xE987; }
public static string Radio { get => ""+(char)0xE988; }
public static string Rating_01 { get => ""+(char)0xE989; }
public static string Rating_02 { get => ""+(char)0xE98A; }
public static string Rating_03 { get => ""+(char)0xE98B; }
public static string RecordscenterStorage { get => ""+(char)0xE98C; }
public static string Rectangle_WF { get => ""+(char)0xE98D; }
public static string Reload { get => ""+(char)0xE98E; }
public static string Remote_Control { get => ""+(char)0xE98F; }
public static string Road_01_WF  { get => ""+(char)0xE990; }
public static string Road_Right_Curve { get => ""+(char)0xE991; }
public static string RSSFeeds { get => ""+(char)0xE992; }
public static string Safe { get => ""+(char)0xE993; }
public static string Save_01 { get => ""+(char)0xE994; }
public static string Scheme { get => ""+(char)0xE995; }
public static string Search { get => ""+(char)0xE996; }
public static string Settings_09 { get => ""+(char)0xE997; }
public static string Shape18_WF { get => ""+(char)0xE998; }
public static string Shop { get => ""+(char)0xE999; }
public static string Show_01_WF { get => ""+(char)0xE99A; }
public static string Show_Progress { get => ""+(char)0xE99B; }
public static string Slash { get => ""+(char)0xE99C; }
public static string SMS { get => ""+(char)0xE99D; }
public static string Speech_01 { get => ""+(char)0xE99E; }
public static string Split { get => ""+(char)0xE99F; }
public static string Step_WF { get => ""+(char)0xE9A0; }
public static string Stop_Clock  { get => ""+(char)0xE9A1; }
public static string StoreCheck { get => ""+(char)0xE9A2; }
public static string Sync { get => ""+(char)0xE9A3; }
public static string Text_Decoration_15 { get => ""+(char)0xE9A4; }
public static string Text_Document { get => ""+(char)0xE9A5; }
public static string To_Do_List_WF { get => ""+(char)0xE9A6; }
public static string Today { get => ""+(char)0xE9A7; }
public static string Toolbox { get => ""+(char)0xE9A8; }
public static string Tools_02 { get => ""+(char)0xE9A9; }
public static string Torch { get => ""+(char)0xE9AA; }
public static string Trash_can_02 { get => ""+(char)0xE9AB; }
public static string Undo_WF { get => ""+(char)0xE9AC; }
public static string User_Profile_1_WF { get => ""+(char)0xE9AD; }
public static string User_Group { get => ""+(char)0xE9AE; }
public static string User_Profile { get => ""+(char)0xE9AF; }
public static string Video { get => ""+(char)0xE9B0; }
public static string View_02_WF { get => ""+(char)0xE9B1; }
public static string Volume_0_Mute { get => ""+(char)0xE9B2; }
public static string Volume_1 { get => ""+(char)0xE9B3; }
public static string Volume_2 { get => ""+(char)0xE9B4; }
public static string Volume_3 { get => ""+(char)0xE9B5; }
public static string Warehouse_01_WF { get => ""+(char)0xE9B6; }
public static string Warning_Shield { get => ""+(char)0xE9B7; }
public static string Web { get => ""+(char)0xE9B8; }
public static string Xamarin { get => ""+(char)0xE9B9; }
public static string Yes_No_Maybe_WT { get => ""+(char)0xE9BA; }
public static string ZPF { get => ""+(char)0xE9BB; }



   }
}

