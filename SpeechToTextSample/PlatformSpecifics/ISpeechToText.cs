using System;
namespace SpeechToTextSample.PlatformSpecifics
{
    public interface ISpeechToText
    {
        void StartSpeechToText();
        void StopSpeechToText();
    }
}
