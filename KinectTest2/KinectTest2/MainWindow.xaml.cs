namespace KinectTest2
{
    using System;
    using System.IO.Ports;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;

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

        public UartManager UartManager { get; private set; }

        public MainWindow()
        {
            this.InitializeComponent();

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

        // COM Part

        private void LoadListButton_Click(object sender, RoutedEventArgs e)
        {
            string[] portNames = SerialPort.GetPortNames();
            COMComboBox.Items.Clear();
            foreach (string portName in portNames)
            {
                COMComboBox.Items.Add(portName);
            }
        }

        private void COMComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object selectedItem = COMComboBox.SelectedItem;
            if (selectedItem == null)
            {
                return;
            }
            if (UartManager != null)
            {
                UartManager.Close();
            }
            String portName = selectedItem.ToString();
            UartManager = new UartManager(portName);
            UartManager.Open();
        }


        private void ForwardMotorButton_Click(object sender, RoutedEventArgs e)
        {
            if (UartManager == null)
            {
                return;
            }
            UartManager.RunMotors();
            Thread.Sleep(1000);
            UartManager.StopMotors();
        }

        private void BackwardMotorButton_Click(object sender, RoutedEventArgs e)
        {
            if (UartManager == null)
            {
                return;
            }
            UartManager.BackwardMotors();
            Thread.Sleep(1000);
            UartManager.StopMotors();
        }

        private void StopMotorButton_Click(object sender, RoutedEventArgs e)
        {
            if (UartManager == null)
            {
                return;
            }
            UartManager.StopMotors();

        }

        private void LeftMotorButton_Click(object sender, RoutedEventArgs e)
        {
            if (UartManager == null)
            {
                return;
            }
            UartManager.RotateLeft();
            Thread.Sleep(1000);
            UartManager.StopMotors();
        }

        private void RightMotorButton_Click(object sender, RoutedEventArgs e)
        {
            if (UartManager == null)
            {
                return;
            }
            UartManager.RotateRight();
            Thread.Sleep(1000);
            UartManager.StopMotors();
        }
    }
}
