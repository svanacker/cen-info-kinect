namespace KinectTest2
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    using Microsoft.Kinect;

    public class DepthModule
    {
        private MainWindow window;

        private KinectSensor kinect;

        public int Min { get; set; }

        public int Max { get; set; }

        public DepthModule(MainWindow window)
        {
            this.window = window;

            this.window.NearDepthMinDistanceTextBox.TextChanged += this.NearDepthMinDistanceTextBox_TextChanged;
            this.window.NearDepthMaxDistanceTextBox.TextChanged += this.NearDepthMaxDistanceTextBox_TextChanged;

            // raise the events once to retreive the initial values from the UI
            this.NearDepthMinDistanceTextBox_TextChanged(this.window.NearDepthMinDistanceTextBox, null);
            this.NearDepthMaxDistanceTextBox_TextChanged(this.window.NearDepthMaxDistanceTextBox, null);
        }

        public void Start(KinectSensor kinect)
        {
            this.kinect = kinect;

            this.kinect.DepthStream.Enable();
            this.kinect.DepthFrameReady += kinect_DepthFrameReady;
        }

        public void Stop()
        {
            this.kinect.DepthFrameReady -= kinect_DepthFrameReady;
            this.kinect.DepthStream.Disable();

            this.kinect = null;
        }

        private void kinect_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            using (DepthImageFrame frame = e.OpenDepthImageFrame())
            {
                ShowDepthImageFrame(frame);
            }
        }

        private void ShowDepthImageFrame(DepthImageFrame frame)
        {
            if (frame == null)
            {
                return;
            }

            var depthPixels = new DepthImagePixel[frame.PixelDataLength];
            var colorPixels = new byte[frame.PixelDataLength * sizeof(int)];
            frame.CopyDepthImagePixelDataTo(depthPixels);

            var bitmap = new WriteableBitmap(frame.Width, frame.Height, 96.0, 96.0, PixelFormats.Bgr32, null);

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

                // To convert to a byte, we're discarding the most-significant
                // rather than least-significant bits.
                // We're preserving detail, although the intensity will "wrap."
                // Values outside the reliable depth range are mapped to 0 (black).

                // Note: Using conditionals in this loop could degrade performance.
                // Consider using a lookup table instead when writing production code.
                // See the KinectDepthViewer class used by the KinectExplorer sample
                // for a lookup table example.
                byte intensity = (byte)(depth >= minDepth && depth <= maxDepth ? depth : 0);


                if (this.Min < depth && depth < this.Max)
                {
                    depthInRangeCount++;

                    // Write out blue byte
                    colorPixels[colorPixelIndex++] = 0;

                    // Write out green byte
                    colorPixels[colorPixelIndex++] = 0;

                    // Write out red byte
                    colorPixels[colorPixelIndex++] = intensity;
                }
                else
                {
                    // Write out blue byte
                    colorPixels[colorPixelIndex++] = intensity;

                    // Write out green byte
                    colorPixels[colorPixelIndex++] = intensity;

                    // Write out red byte
                    colorPixels[colorPixelIndex++] = intensity;
                }

                // We're outputting BGR, the last byte in the 32 bits is unused so skip it
                // If we were outputting BGRA, we would write alpha here.
                ++colorPixelIndex;
            }

            bitmap.WritePixels(new Int32Rect(0, 0, bitmap.PixelWidth, bitmap.PixelHeight), colorPixels, bitmap.PixelWidth * sizeof(int), 0);

            this.window.ImageCanvas.Background = new ImageBrush(bitmap);
            this.window.NearDepthCountValue.Content = depthInRangeCount.ToString();
        }

        private void NearDepthMinDistanceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Min = Convert.ToInt32(this.window.NearDepthMinDistanceTextBox.Text);
        }

        private void NearDepthMaxDistanceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Max = Convert.ToInt16(this.window.NearDepthMaxDistanceTextBox.Text);
        }
    }
}
