using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace monopoly
{
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
            Task.Run(()=> {
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
