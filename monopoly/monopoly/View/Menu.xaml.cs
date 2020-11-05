using monopoly.ViewModel;
using SkiaSharp.Views.Forms;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace monopoly.View
{
    public partial class Menu : ContentPage
    {
        private BGanimator bgAnimator;
        public Menu()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(Navigation);
            bgAnimator = new BGanimator(BG);
        }
        //canvasView.InvalidateSurface();
        private void PaintText(object sender, SKPaintSurfaceEventArgs args)
        {
            new SKPaintText().PaintText(sender, args.Surface, args.Info);
        }
        protected override void OnAppearing() //можно настроить поведение немедленно до того, как Page становится видимым
        {
            bgAnimator.animationStart();
        }
        protected override void OnDisappearing() //можно настроить поведение когда Page исчезает
        {
            bgAnimator.animationStop();
        }

    }
}
