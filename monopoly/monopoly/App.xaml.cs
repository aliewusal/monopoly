﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using monopoly.View;

namespace monopoly
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new View.Menu());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
