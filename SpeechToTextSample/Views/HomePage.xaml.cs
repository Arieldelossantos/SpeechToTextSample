using System;
using System.Collections.Generic;
using SpeechToTextSample.PlatformSpecifics;
using SpeechToTextSample.ViewModels;
using Xamarin.Forms;

namespace SpeechToTextSample.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            var _speechToText = DependencyService.Resolve<ISpeechToText>();
            BindingContext = new HomeViewModel(_speechToText);
        }
    }
}
