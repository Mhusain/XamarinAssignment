using System.IO;
using System.Threading.Tasks;

namespace SabicApp.Services
{
    public static class AudioRecorderService
    {
        private static Plugin.AudioRecorder.AudioRecorderService audioRecorder;

        public static async Task<Stream> StartRecording()
        {
            var filePath = Path.Combine(Path.GetTempPath(), "recording.wav");

            audioRecorder = new Plugin.AudioRecorder.AudioRecorderService()
            {
                FilePath = filePath,
                StopRecordingOnSilence = false,
                SilenceThreshold = -1
            };

            await audioRecorder.StartRecording();

            return audioRecorder.GetAudioFileStream();
        }

        public static async Task StopRecording()
        {
            if (audioRecorder != null)
            {
                await audioRecorder.StopRecording();
                audioRecorder = null;
            }
        }
    }
}

