using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace monopoly
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
            Task.Run(() => {
                BG.Scale = 1.1;
                while (true)
                {
                    BG.TranslateTo(-50, 0, 10000).Wait();

                    BG.TranslateTo(50, 0, 10000).Wait();
                }

            });
        }
    }
}