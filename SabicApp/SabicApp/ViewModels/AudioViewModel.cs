using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using SabicApp.Services;

namespace SabicApp.ViewModels
{
	public class AudioViewModel : BindableObject
    {
        private bool isRecording;
        public bool IsRecording
        {
            get { return isRecording; }
            set
            {
                isRecording = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNotRecording));
            }
        }

        public bool IsNotRecording => !IsRecording;

        private string audioBase64;
        public string AudioBase64
        {
            get { return audioBase64; }
            set
            {
                audioBase64 = value;
                OnPropertyChanged();
            }
        }

        public Command StartRecordingCommand { get; }
        public Command StopRecordingCommand { get; }

        public AudioViewModel()
        {
            StartRecordingCommand = new Command(StartRecording, () => IsNotRecording);
            StopRecordingCommand = new Command(StopRecording, () => IsRecording);
        }

        private async void StartRecording()
        {
            IsRecording = true;
            var audioStream = await AudioRecorderService.StartRecording();

            // Convert audio stream to base64
            byte[] audioBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                audioStream.CopyTo(ms);
                audioBytes = ms.ToArray();
            }
            AudioBase64 = Convert.ToBase64String(audioBytes);

            IsRecording = false;
        }

        private async void StopRecording()
        {
            IsRecording = false;
            await AudioRecorderService.StopRecording();
        }

        public async Task CheckAndRequestPermissions()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Microphone>();

            if (status != PermissionStatus.Granted)
            {
                var result = await Permissions.RequestAsync<Permissions.Microphone>();

                if (result != PermissionStatus.Granted)
                {
                    // Permission denied, handle accordingly
                    // For example, display an error message or disable recording functionality
                }
            }
        }
    }
}

