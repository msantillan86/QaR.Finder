﻿using QaR.Finder.Mobile.Services;
using QaR.Finder.Mobile.Views;
using QaR.Finder.Mobile.Views.Paginas;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QaR.Finder.Mobile
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        //To debug on Android emulators run the web backend against .NET Core not IIS
        //If using other emulators besides stock Google images you may need to adjust the IP address
        public static string AzureBackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "https://qarfinderapi.herokuapp.com/" : "http://localhost:5000";
        public static bool UseMockDataStore = false;

        public App()
        {
            InitializeComponent();

            //if (UseMockDataStore)
            //    DependencyService.Register<MockDataStore>();
            //else
            //    DependencyService.Register<AzureDataStore>();
            // PAGINA PRINCIPAL DE LA APP
            //MainPage = new AppShell();

            MainPage = new NavigationPage(new PaginaInicioDeSesion());            
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
