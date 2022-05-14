using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFCustomFonts.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkiaPage : ContentPage
    {
        public SkiaPage()
        {
            InitializeComponent();
        }

        private void OnPainting(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            // we get the current surface from the event args
            var surface = e.Surface;
            // then we get the canvas that we can draw on
            var canvas = surface.Canvas;
            // clear the canvas / view
            canvas.Clear(SKColors.White);

            // create the paint for the text
            var textPaint = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                Color = SKColors.Navy,
                TextSize = 80,
                Typeface = SKTypeface.FromStream(GetStreamFromResources(typeof(SkiaPage), "XFCustomFonts.Fonts.desyrel.ttf"))
            };

            // draw the text (from the baseline)
            canvas.DrawText("SkiaSharp", 60, 160 + 80, textPaint);

            textPaint.Typeface = SKTypeface.FromStream(GetStreamFromResources(typeof(SkiaPage), "XFCustomFonts.Fonts.IconFont.ttf"));

            canvas.DrawText(ZPFFonts.IF.GetContent(ZPFFonts.IF.ZPF), 60, 160 + 80 + 80, textPaint);
        }

        public static Stream GetStreamFromResources(Type type, string resourceName)
        {
            var assembly = type.GetTypeInfo().Assembly;
            return assembly.GetManifestResourceStream(resourceName);
        }
    }
}