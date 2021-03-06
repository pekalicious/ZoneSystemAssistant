﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZoneSystemAssistant.Services;
using ZoneSystemAssistant.Views;

namespace ZoneSystemAssistant
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Values.Load();

            DependencyService.Register<UniversalUserPrefsStore>();
            MainPage = new NavigationPage(new ItemsPage());
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
