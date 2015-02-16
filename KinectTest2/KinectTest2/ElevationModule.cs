namespace KinectTest2
{
    using System;
    using System.Threading;
    using Microsoft.Kinect;

    public class ElevationModule
    {
        private MainWindow window;

        private KinectSensor kinect;

        public ElevationModule(MainWindow window)
        {
            this.window = window;
        }

        public void Start(KinectSensor kinect)
        {
            this.kinect = kinect;

            this.window.ElevationSlider.Value = this.kinect.ElevationAngle;
            this.window.ElevationSlider.ValueChanged += this.ElevationSlider_ValueChanged;
        }

        public void Stop()
        {
            if (this.kinect == null) return;

            this.window.ElevationSlider.ValueChanged -= this.ElevationSlider_ValueChanged;
            this.window.ElevationSlider.Value = 0;

            this.kinect = null;
        }

        private void ElevationSlider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.kinect == null) return;

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    this.kinect.ElevationAngle = (int)this.window.ElevationSlider.Value;
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(10);
                }
            }
        }
    }
}
