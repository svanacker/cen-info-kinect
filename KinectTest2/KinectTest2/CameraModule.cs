namespace KinectTest2
{
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    using Microsoft.Kinect;

    public class CameraModule : IKinectModule
    {
        private MainWindow window;

        private KinectSensor kinect;

        public CameraModule(MainWindow window)
        {
            this.window = window;
        }

        public void Start(KinectSensor kinect)
        {
            this.kinect = kinect;

            this.kinect.ColorStream.Enable();
            this.kinect.ColorFrameReady += this.kinect_ColorFrameReady;
        }

        public void Stop()
        {
            this.kinect.ColorFrameReady -= kinect_ColorFrameReady;
            this.kinect.ColorStream.Disable();

            this.kinect = null;
        }

        private void kinect_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs colorImageFrameReadyEventArgs)
        {
            if (this.window.VideoRadioButton.IsChecked == true)
            {
                using (ColorImageFrame frame = colorImageFrameReadyEventArgs.OpenColorImageFrame())
                {
                    this.ShowColorImageFrame(frame);
                }
            }
        }

        private void ShowColorImageFrame(ColorImageFrame frame)
        {
            if (frame == null)
            {
                return;
            }

            var pixelData = new byte[frame.PixelDataLength];
            frame.CopyPixelDataTo(pixelData);
            int stride = frame.Width * frame.BytesPerPixel;
            var bitmapSource = BitmapSource.Create(frame.Width, frame.Height, 96, 96, PixelFormats.Bgr32, null, pixelData, stride);

            this.window.ImageCanvas.Background = new ImageBrush(bitmapSource);
        }
    }
}
