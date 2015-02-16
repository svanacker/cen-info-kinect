namespace KinectTest2
{
    using System;
    using System.IO.Ports;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

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

            this.cameraModule = new CameraModule(this);
            this.depthModule = new DepthModule(this);
            this.recognitionModule = new RecognitionModule(this);
            this.skeletonsModule = new SkeletonsModule(this);
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            KinectSensorCollection kinectSensorCollection = KinectSensor.KinectSensors;
            int sensorCount = kinectSensorCollection.Count;
            if (sensorCount > 0)
            {
                kinect = kinectSensorCollection[0];
                kinectSensorCollection.StatusChanged += (o, args) =>
                {
                    KinectStatusValue.Content = args.Status.ToString();
                };

                if (LaunchButton.Content.ToString() == "Start")
                {
                    kinect.Start();
                    KinectIdValue.Content = kinect.DeviceConnectionId;
                    LaunchButton.Content = "Stop";
                    ElevationSlider.Value = kinect.ElevationAngle;

                    this.StartKinectDisplay();
                    this.recognitionModule.Start(kinect);
                    this.skeletonsModule.Start(this.kinect);
                }
                else
                {
                    this.skeletonsModule.Stop();
                    this.StopKinectDisplay();
                    kinect.Stop();
                    kinect = null;
                    KinectIdValue.Content = "-";
                    KinectStatusValue.Content = "-";
                    LaunchButton.Content = "Start";
                }
            }
        }


        private void StartKinectDisplay()
        {
            if (VideoRadioButton.IsChecked == true)
            {
                this.cameraModule.Start(this.kinect);
            }
            else if (DepthRadioButton.IsChecked == true)
            {
                this.depthModule.Start(this.kinect);
            }
        }


        private void StopKinectDisplay()
        {
            if (VideoRadioButton.IsChecked == true)
            {
                this.cameraModule.Stop();
            }
            else if (DepthRadioButton.IsChecked == true)
            {
                this.depthModule.Stop();
            }
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

        private void VideoRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            if (this.kinect == null) return;

            this.cameraModule.Start(this.kinect);
        }

        private void VideoRadioButton_OnUnchecked(object sender, RoutedEventArgs e)
        {
            if (this.kinect == null) return;

            this.cameraModule.Stop();
        }

        private void DepthRadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            if (this.kinect == null) return;

            this.depthModule.Start(this.kinect);
        }

        private void DepthRadioButton_OnUnchecked(object sender, RoutedEventArgs e)
        {
            if (this.kinect == null) return;

            this.depthModule.Stop();
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

        private void DrawSkeletonCheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            this.skeletonsModule.ReStart();
        }

        private void DrawSkeletonCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            this.skeletonsModule.ReStart();
        }

        private void GestureCheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            this.skeletonsModule.ReStart();
        }

        private void GestureCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            this.skeletonsModule.ReStart();
        }
    }
}
