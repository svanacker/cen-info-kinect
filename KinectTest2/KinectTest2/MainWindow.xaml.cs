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

        private DepthModule depthModule;

        private RecognitionModule recognitionModule;

        public UartManager UartManager { get; private set; }

        private SkeletonsModule skeletonsModule;

        public MainWindow()
        {
            this.InitializeComponent();

            this.TrackKinectStatus();

            this.cameraModule = new CameraModule(this);
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
                KinectIdValue.Content = kinect.DeviceConnectionId;
                LaunchButton.Content = "Stop";
                ElevationSlider.Value = kinect.ElevationAngle;

                this.cameraModule.Start(this.kinect);
                this.depthModule.Start(this.kinect);
                this.recognitionModule.Start(kinect);
                this.skeletonsModule.Start(this.kinect);
            }
        }

        private void StopKinect()
        {
            this.skeletonsModule.Stop();
            this.depthModule.Stop();
            this.cameraModule.Stop();
            this.kinect.Stop();
            this.kinect = null;
            KinectIdValue.Content = "-";
            LaunchButton.Content = "Start";
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.kinect == null) return;

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    kinect.ElevationAngle = (int) ElevationSlider.Value;
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(10);
                }
            }
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


        private void TestMotorButton_Click(object sender, RoutedEventArgs e)
        {
            if (UartManager == null)
            {
                return;
            }
            UartManager.RunMotors();
        }

        private void StopMotorButton_OnClickMotorButton_Click(object sender, RoutedEventArgs e)
        {
            if (UartManager == null)
            {
                return;
            }
            UartManager.StopMotors();
        }

        private void RecognitionCheckBox_OnCheckedCheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
    }

        private void RecognitionCheckBox_OnUncheckedCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
