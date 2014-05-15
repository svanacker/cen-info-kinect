using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Kinect;

namespace KinectTest1
{
    public partial class Form1 : Form
    {
        private KinectSensor kinect;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KinectSensorCollection kinectSensorCollection = KinectSensor.KinectSensors;
            int sensorCount = kinectSensorCollection.Count;
            if (sensorCount > 0)
            {
                kinect = kinectSensorCollection[0];
                kinectSensorCollection.StatusChanged += (o, args) =>
                {
                    KinectStatusValue.Text = args.Status.ToString();
                };

                if (LaunchButton.Text == "Start")
                {
                    kinect.Start();
                    KinectIdValue.Text = kinect.DeviceConnectionId;
                    LaunchButton.Text = "Stop";

                    kinect.ColorStream.Enable();
                }
                else
                {
                    kinect.Stop();
                    KinectIdValue.Text = "-";
                    KinectStatusValue.Text = "-";
                    LaunchButton.Text = "Start";
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (var frame = kinect.ColorStream.OpenNextFrame(0))
            {
                var pixelData = new byte[frame.PixelDataLength];
                frame.CopyPixelDataTo(pixelData);
                int stride = frame.Width*frame.BytesPerPixel;
                BitmapSource bitmapSource = BitmapSource.Create(frame.Width, frame.Height, 96, 96, PixelFormats.Bgr32, null, pixelData,
                    stride);

                pictureBox1.BackgroundImage = BitmapFromSource(bitmapSource);
            }
        }

        private System.Drawing.Bitmap BitmapFromSource(BitmapSource bitmapsource)
        {
            System.Drawing.Bitmap bitmap;
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapsource));
                enc.Save(outStream);
                bitmap = new System.Drawing.Bitmap(outStream);
            }
            return bitmap;
        }
    }
}
