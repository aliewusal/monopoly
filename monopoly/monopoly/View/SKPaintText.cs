using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace monopoly.View
{
    class SKPaintText
    {
        private static SKTypeface GetTypeface(string fullFontName)
        {
            SKTypeface result;

            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("monopoly.resource.fonts." + fullFontName);
            if (stream == null)
                return null;

            result = SKTypeface.FromStream(stream);
            return result;
        }
        public void PaintText(object sender, SKSurface surface, SKImageInfo info)
        {
            bool textForLobby = false;
            bool textForFriend = false;
            var Bind = sender as Xamarin.Forms.View;
            string text = (string)Bind.BindingContext;
            text = text.ToUpper();

            if(text[text.Length-1] == ':')
            {
                text = text.Remove(text.Length - 1);
                textForLobby = true;
            }
            if (text[text.Length - 1] == ';')
            {
                text = text.Remove(text.Length - 1);
                textForFriend = true;
            }

            using (SKCanvas canvas = surface.Canvas)
            {
                canvas.Clear();

                float dx = -10;
                float dy = 10;
                float sigmaX = 3;
                float sigmaY = 3;

                // Create an SKPaint object to display the text
                using (SKPaint textPaint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    StrokeWidth = 4,
                    IsAntialias = true,
                    Color = SKColor.Parse("#000")
                })
                {
                    using (SKPaint textPaintFill = new SKPaint
                    {
                        Style = SKPaintStyle.Fill,
                        IsAntialias = true,
                        Color = SKColor.Parse("#E7D014")
                    })
                    {
                        textPaintFill.Typeface = GetTypeface("AmericanCaptain.ttf");
                        textPaint.Typeface = textPaintFill.Typeface;

                        // Adjust TextSize property so text is 95% of screen width
                        float textWidth = textPaint.MeasureText(text);

                        if (textForLobby && text.Length < 10)
                            textWidth = 70;

                        if (textForFriend && text.Length < 10)
                            textWidth = 50;

                        textPaint.TextSize = 0.80f * info.Width * textPaint.TextSize / textWidth;
                        textPaintFill.TextSize = 0.80f * info.Width * textPaintFill.TextSize / textWidth;


                        // Find the text bounds
                        SKRect textBounds = new SKRect();
                        textPaint.MeasureText(text, ref textBounds);

                        textPaintFill.ImageFilter = SKImageFilter.CreateDropShadow(
                                                        dx,
                                                        dy,
                                                        sigmaX,
                                                        sigmaY,
                                                        SKColor.Parse("#55000000"));
                        textPaintFill.MeasureText(text, ref textBounds);

                        // Calculate offsets to center the text on the screen
                        float xText = info.Width / 2 - textBounds.MidX;
                        float yText = info.Height / 2 - textBounds.MidY;

                        // And draw the text
                        canvas.DrawText(text, xText, yText, textPaint);
                        canvas.DrawText(text, xText, yText, textPaintFill);
                    }
                }
            }
        }


        public void PaintTextGL(object sender, SKSurface surface, GRBackendRenderTarget backendRenderTarget)
        {
            float dx = -10;
            float dy = 10;
            float sigmaX = 3;
            float sigmaY = 3;

            var Bind = sender as Xamarin.Forms.View;
            string text = (string)Bind.BindingContext;

            var canvas = surface.Canvas;
            canvas.Clear();

            using (SKPaint textPaintFill = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                IsAntialias = true,
                Color = SKColor.Parse("#E7D014")
            })
            {
                using (SKPaint textPaint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    StrokeWidth = 4,
                    IsAntialias = true,
                    Color = SKColor.Parse("#000")
                })
                {
                    textPaintFill.Typeface = GetTypeface("AmericanCaptain.ttf");
                    textPaint.Typeface = textPaintFill.Typeface;
                    float textWidth = textPaintFill.MeasureText(text);
                    textPaintFill.TextSize = 0.85f * backendRenderTarget.Width * textPaintFill.TextSize / textWidth;
                    textPaint.TextSize = 0.85f * backendRenderTarget.Width * textPaint.TextSize / textWidth;
                    SKRect textBounds = new SKRect();
                    textPaint.MeasureText(text, ref textBounds);
                    textPaintFill.ImageFilter = SKImageFilter.CreateDropShadow(
                                                        dx,
                                                        dy,
                                                        sigmaX,
                                                        sigmaY,
                                                        SKColor.Parse("#55000000"));
                    textPaintFill.MeasureText(text, ref textBounds);



                    float xText = backendRenderTarget.Width / 2 - textBounds.MidX;
                    float yText = backendRenderTarget.Height / 2 - textBounds.MidY;

                    canvas.DrawText(text, xText, yText, textPaint);
                    canvas.DrawText(text, xText, yText, textPaintFill);
                }
            }
        }

    }
}
