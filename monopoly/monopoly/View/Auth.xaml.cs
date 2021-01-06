using monopoly.ViewModel;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace monopoly.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Auth : ContentPage
    {
        private BGanimator bgAnimator;
        public Auth()
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