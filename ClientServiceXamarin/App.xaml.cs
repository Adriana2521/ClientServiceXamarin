using System;
using Xamarin.Forms;
using ClientServiceXamarin.Views;
using Xamarin.Forms.Xaml;

namespace ClientServiceXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new EncuestaCliente();
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
