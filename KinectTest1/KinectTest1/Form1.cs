using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;

namespace KinectTest1
{
    public partial class Form1 : Form
    {
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
                var kinect = kinectSensorCollection[0];
                kinectSensorCollection.StatusChanged += (o, args) =>
                {
                    KinectStatusValue.Text = args.Status.ToString();
                };

                if (LaunchButton.Text == "Start")
                {
                    kinect.Start();
                    KinectIdValue.Text = kinect.DeviceConnectionId;
                    LaunchButton.Text = "Stop";
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
    }
}
