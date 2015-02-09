
namespace KinectTest2
{
    using System;
    using System.Threading;
    using System.Windows;
    using Microsoft.Kinect;
    using Microsoft.Speech.AudioFormat;
    using Microsoft.Speech.Recognition;

    public class RecognitionModule
    {
        private MainWindow window;

        private KinectSensor kinect;
        private SpeechRecognitionEngine speechRecognitionEngine;
        private RecognizerInfo recognizer;

        // SOUND PART : http://kin-educate.blogspot.fr/2012/06/speech-recognition-for-kinect-easy-way.html

        public RecognitionModule(MainWindow window)
        {
            this.window = window;
        }

        public void Start(KinectSensor kinect)
        {
            this.kinect = kinect;
            // Initialize the recognizer
            recognizer = GetRecognizer();

            if (recognizer != null)
            {
                // Initialize the Engine
                InitSpeechRecognitionEngine();

                var thread = new Thread(StartAudioStream);
                thread.Start();
            }
        }

        private RecognizerInfo GetRecognizer()
        {
            foreach (var recognizer in SpeechRecognitionEngine.InstalledRecognizers())
            {
                string value;
                recognizer.AdditionalInfo.TryGetValue("Kinect", out value);
                if ("True".Equals(value, StringComparison.OrdinalIgnoreCase) &&
                    "fr-FR".Equals(recognizer.Culture.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return recognizer;
                }
            }
            return null;
        }

        private SpeechRecognitionEngine InitSpeechRecognitionEngine()
        {
            speechRecognitionEngine = new SpeechRecognitionEngine(recognizer.Id);
            var choices = new Choices();
            choices.Add("hello");
            choices.Add("goodbye");

            var grammarBuilder = new GrammarBuilder {Culture = recognizer.Culture};
            grammarBuilder.Append(choices);

            var grammar = new Grammar(grammarBuilder);

            speechRecognitionEngine.LoadGrammar(grammar);

            speechRecognitionEngine.SpeechRecognized += SpeechRecognitionEngineOnSpeechRecognized;
            speechRecognitionEngine.SpeechHypothesized += SpeechRecognitionEngineOnSpeechHypothesized;
            speechRecognitionEngine.SpeechRecognitionRejected += SpeechRecognitionEngineOnSpeechRejected;
            speechRecognitionEngine.SpeechDetected += SpeechRecognitionEngineOnSpeechDetected;

            return speechRecognitionEngine;
        }

        private void StartAudioStream()
        {
            //set sensor audio source to variable
            var audioSource = kinect.AudioSource;
            //we want it to be set to adaptive
            audioSource.BeamAngleMode = BeamAngleMode.Adaptive;

            var kinectStream = audioSource.Start();

            var speechAudioFormatInfo = new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null);
            speechRecognitionEngine.SetInputToAudioStream(kinectStream, speechAudioFormatInfo);
            speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);

            // reduce background and ambient noise for better accuracy
            kinect.AudioSource.EchoCancellationMode = EchoCancellationMode.None;
            kinect.AudioSource.AutomaticGainControlEnabled = false;
        }

        private void SpeechRecognitionEngineOnSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence * 100.0f < (float) window.ConfidenceSlider.Value)
            {
                window.LastRecognitionStatusLabel.Content = "";
                return;
            }
            window.LastRecognitionStatusLabel.Content = "Recognized";
            window.LastRecognizedWordLabel.Content = e.Result.Text;
        }

        private void SpeechRecognitionEngineOnSpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            window.LastRecognitionStatusLabel.Content = "Hypothesized";
            window.LasthHypothesizedWordLabel.Content = e.Result.Text;
        }

        private void SpeechRecognitionEngineOnSpeechRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            window.LastRecognitionStatusLabel.Content = "";
            window.LasthHypothesizedWordLabel.Content = "";
            Console.WriteLine("Rejected : {0}", e.Result.Text);
        }

        private void SpeechRecognitionEngineOnSpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            if (window.SpeechDetectorIcon.Visibility == Visibility.Visible)
            {
                window.SpeechDetectorIcon.Visibility = Visibility.Hidden;
            }
            else
            {
                window.SpeechDetectorIcon.Visibility = Visibility.Visible;

            }
        }
    }
}
