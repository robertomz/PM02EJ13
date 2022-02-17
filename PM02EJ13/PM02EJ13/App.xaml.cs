﻿using PM02EJ13.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM02EJ13
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new HomePage());
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
