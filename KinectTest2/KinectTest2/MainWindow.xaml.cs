using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;

namespace KinectTest2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KinectSensor kinect;

        private int min = 300;

        private int max = 400;

        public MainWindow()
        {
            InitializeComponent();
            NearDepthMinDistanceTextBox.Text = min.ToString();
            NearDepthMaxDistanceTextBox.Text = max.ToString();
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
                    kinect.ColorStream.Enable();
                    kinect.ColorFrameReady += KinectOnColorFrameReady;
                    kinect.DepthStream.Enable();
                    kinect.DepthFrameReady += KinectOnDepthFrameReady;
                    ElevationSlider.Value = kinect.ElevationAngle;
                }
                else
                {
                    kinect.Stop();
                    KinectIdValue.Content = "-";
                    KinectStatusValue.Content = "-";
                    LaunchButton.Content = "Start";
                }
            }
        }

        private void KinectOnDepthFrameReady(object sender, DepthImageFrameReadyEventArgs depthImageFrameReadyEventArgs)
        {
            if (true == DepthRadioButton.IsChecked)
            {
                using (DepthImageFrame frame = depthImageFrameReadyEventArgs.OpenDepthImageFrame())
                {
                    ShowDepthImageFrame(frame);
                }
            }
        }

        private void KinectOnColorFrameReady(object sender, ColorImageFrameReadyEventArgs colorImageFrameReadyEventArgs)
        {
            if (true == VideoRadioButton.IsChecked)
            {
                using (ColorImageFrame frame = colorImageFrameReadyEventArgs.OpenColorImageFrame())
                {
                    ShowColorImageFrame(frame);
                }
            }
        }

        private void TakePicture_Click(object sender, RoutedEventArgs e)
        {
            using (ColorImageFrame frame = kinect.ColorStream.OpenNextFrame(0))
            {
                ShowColorImageFrame(frame);
            }
        }

        private void ShowDepthImageFrame(DepthImageFrame frame)
        {
            if (frame == null)
            {
                return;
            }
            DepthImagePixel[] depthPixels = new DepthImagePixel[frame.PixelDataLength];
            byte[] colorPixels = new byte[frame.PixelDataLength*sizeof (int)];
            frame.CopyDepthImagePixelDataTo(depthPixels);

            WriteableBitmap bitmap = new WriteableBitmap(frame.Width, frame.Height, 96.0, 96.0, PixelFormats.Bgr32, null);

            // Get the min and max reliable depth for the current frame
            int minDepth = frame.MinDepth;
            int maxDepth = frame.MaxDepth;

            int depthInRangeCount = 0;

            // Convert the depth to RGB
            int colorPixelIndex = 0;
            for (int i = 0; i < depthPixels.Length; ++i)
            {
                // Get the depth for this pixel
                short depth = depthPixels[i].Depth;

                if (depth > min && depth < max)
                {
                    depthInRangeCount++;
                }

                // To convert to a byte, we're discarding the most-significant
                // rather than least-significant bits.
                // We're preserving detail, although the intensity will "wrap."
                // Values outside the reliable depth range are mapped to 0 (black).

                // Note: Using conditionals in this loop could degrade performance.
                // Consider using a lookup table instead when writing production code.
                // See the KinectDepthViewer class used by the KinectExplorer sample
                // for a lookup table example.
                byte intensity = (byte) (depth >= minDepth && depth <= maxDepth ? depth : 0);

                // Write out blue byte
                colorPixels[colorPixelIndex++] = intensity;

                // Write out green byte
                colorPixels[colorPixelIndex++] = intensity;

                // Write out red byte                        
                colorPixels[colorPixelIndex++] = intensity;

                // We're outputting BGR, the last byte in the 32 bits is unused so skip it
                // If we were outputting BGRA, we would write alpha here.
                ++colorPixelIndex;
            }

            bitmap.WritePixels(new Int32Rect(0, 0, bitmap.PixelWidth, bitmap.PixelHeight), colorPixels,
                bitmap.PixelWidth*sizeof (int), 0);
            ImageCanvas.Background = new ImageBrush(bitmap);

            /*
            frame.CopyPixelDataTo(pixelData);
            int stride = frame.Width * frame.BytesPerPixel;
            BitmapSource bitmapSource = BitmapSource.Create(frame.Width, frame.Height, 96, 96, PixelFormats.Bgr32, null, pixelData,
                stride);

            ImageCanvas.Background = new ImageBrush(bitmapSource);
             * */

            NearDepthCountValue.Content = depthInRangeCount.ToString();
        }

        private void ShowColorImageFrame(ColorImageFrame frame)
        {
            var pixelData = new byte[frame.PixelDataLength];
            frame.CopyPixelDataTo(pixelData);
            int stride = frame.Width*frame.BytesPerPixel;
            BitmapSource bitmapSource = BitmapSource.Create(frame.Width, frame.Height, 96, 96, PixelFormats.Bgr32, null,
                pixelData,
                stride);

            ImageCanvas.Background = new ImageBrush(bitmapSource);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            kinect.ElevationAngle = (int) ElevationSlider.Value;
        }

        private void NearDepthMinDistanceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            min = Convert.ToInt32(NearDepthMinDistanceTextBox.Text);
        }

        private void NearDepthMaxDistanceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            max = Convert.ToInt16(NearDepthMaxDistanceTextBox.Text);
        }
    }
}
