using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parcial2Xamarin
{
    public partial class App : Application
    {
        public static object Producto { get; internal set; }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
