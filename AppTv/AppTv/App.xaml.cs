
using AppTv.Views;
using AppTv.Persistence;
using Xamarin.Forms;
using System.IO;
using System;
using Microsoft.EntityFrameworkCore.Storage;


namespace AppTv
{


    public partial class App : Application
    {

        
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());

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
