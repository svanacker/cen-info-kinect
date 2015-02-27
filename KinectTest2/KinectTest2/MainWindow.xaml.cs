namespace KinectTest2
{
    using System.Windows;

    using Microsoft.Kinect;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KinectSensor kinect;

        private CameraModule cameraModule;

        private ElevationModule elevationModule;

        private DepthModule depthModule;

        private RecognitionModule recognitionModule;

        private SkeletonsModule skeletonsModule;

        public MainWindow()
        {
            this.InitializeComponent();
            this.InitializeComComponent();

            this.TrackKinectStatus();

            this.cameraModule = new CameraModule(this);
            this.elevationModule = new ElevationModule(this);
            this.depthModule = new DepthModule(this);
            this.recognitionModule = new RecognitionModule(this);
            this.skeletonsModule = new SkeletonsModule(this);
        }

        private void TrackKinectStatus()
        {
            var kinectSensorCollection = KinectSensor.KinectSensors;
            if (kinectSensorCollection.Count > 0)
            {
                this.KinectStatusValue.Content = kinectSensorCollection[0].Status;
            }
            else
            {
                this.KinectStatusValue.Content = KinectStatus.Disconnected;
            }

            kinectSensorCollection.StatusChanged += (o, args) =>
            {
                this.KinectStatusValue.Content = args.Status;
                if (args.Status == KinectStatus.Disconnected)
                {
                    this.StopKinect();
                }
            };
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            if (LaunchButton.Content.ToString() == "Start")
            {
                this.StartKinect();
            }
            else
            {
                this.StopKinect();
            }
        }

        private void StartKinect()
        {
            var kinectSensorCollection = KinectSensor.KinectSensors;
            if (kinectSensorCollection.Count > 0)
            {
                this.kinect = kinectSensorCollection[0];
                this.kinect.Start();
                KinectIdValue.Content = this.kinect.DeviceConnectionId;
                LaunchButton.Content = "Stop";

                this.cameraModule.Start(this.kinect);
                this.elevationModule.Start(this.kinect);
                this.depthModule.Start(this.kinect);
                this.recognitionModule.Start(this.kinect);
                this.skeletonsModule.Start(this.kinect);
            }
        }

        private void StopKinect()
        {
            this.skeletonsModule.Stop();
            this.depthModule.Stop();
            this.elevationModule.Stop();
            this.cameraModule.Stop();
            this.kinect.Stop();
            this.kinect = null;
            KinectIdValue.Content = "-";
            LaunchButton.Content = "Start";
        }
    }
}
