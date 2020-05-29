using System;
using SpeechToTextSample.PlatformSpecifics;
using SpeechToTextSample.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpeechToTextSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            RegisterDepencencies();

            MainPage = new HomePage();
        }

        private void RegisterDepencencies()
        {
            DependencyService.Register<ISpeechToText>();
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
