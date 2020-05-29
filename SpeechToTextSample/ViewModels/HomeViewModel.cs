using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SpeechToTextSample.PlatformSpecifics;
using Xamarin.Forms;
using PropertyChanged;

namespace SpeechToTextSample.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class HomeViewModel
    {
        public ICommand TapToSpeechCommand { get; set; }
        public ICommand ClearTextCommand { get; set; }

        public string YourSpeech { get; set; }

        private readonly ISpeechToText _speechToText;

        public HomeViewModel(ISpeechToText speechToText)
        {
            _speechToText = speechToText;

            RegisterCommands();
            SubscribeReceiver();
        }

        private void RegisterCommands()
        {
            TapToSpeechCommand = new Command(() => tapToSpeech());
            ClearTextCommand = new Command(() => YourSpeech = string.Empty);
        }

        private void tapToSpeech()
        {
            _speechToText.StartSpeechToText();
        }

        private void SubscribeReceiver()
        {
            SpeechToTextReceiver();
        }

        private void SpeechToTextReceiver()
        {
            MessagingCenter.Subscribe<IMessageSender, string>(this, "STT", (sender, args) =>
            {
                SpeechToTextFinalResultRecieved(args);
            });

            MessagingCenter.Subscribe<ISpeechToText, string>(this, "STT", (sender, args) =>
            {
                SpeechToTextFinalResultRecieved(args);
            });
        }

        private void SpeechToTextFinalResultRecieved(string args)
        {
            YourSpeech = args;
        }
    }
}
