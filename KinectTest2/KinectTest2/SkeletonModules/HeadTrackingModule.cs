namespace KinectTest2.SkeletonModules
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;

    using Microsoft.Kinect;

    public class HeadTrackingModule : ISkeletonModule
    {
        private KinectSensor kinect;
        private MainWindow window;

        private readonly Ellipse headEllipse = new Ellipse();
        private readonly Label idLabel = new Label();

        public HeadTrackingModule(KinectSensor kinect, MainWindow window, int skeletonId, Brush drawingColor)
        {
            this.kinect = kinect;
            this.window = window;

            this.headEllipse.Stroke = drawingColor;
            this.window.ImageCanvas.Children.Add(this.headEllipse);

            this.idLabel.Foreground = drawingColor;
            this.idLabel.FontFamily = new FontFamily("Segoe WP Black");
            this.idLabel.FontSize = 36;
            this.idLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
            this.idLabel.Content = skeletonId.ToString();
            this.window.ImageCanvas.Children.Add(this.idLabel);
        }

        public void Dispose()
        {
            this.kinect = null;
            this.window.ImageCanvas.Children.Remove(this.headEllipse);
            this.window.ImageCanvas.Children.Remove(this.idLabel);
        }

        public void Follow(Skeleton skeleton, int skeletonIndex)
        {
            var headLoc = skeleton.Joints[JointType.Head].Position;
            var neckLoc = skeleton.Joints[JointType.ShoulderCenter].Position;
            var coordMapper = this.kinect.CoordinateMapper;
            var colorImagePointOfHead = coordMapper.MapSkeletonPointToColorPoint(headLoc, ColorImageFormat.RgbResolution640x480Fps30);
            var colorImagePointOfNeck = coordMapper.MapSkeletonPointToColorPoint(neckLoc, ColorImageFormat.RgbResolution640x480Fps30);

            this.idLabel.Content = string.Format("{0}/{1}", skeleton.TrackingId, skeletonIndex);
            this.DrawEllipse(colorImagePointOfHead, colorImagePointOfNeck);
            this.DrawSkeletonId(colorImagePointOfHead);
        }

        private void DrawEllipse(ColorImagePoint colorImagePointOfHead, ColorImagePoint colorImagePointOfNeck)
        {
            var xdiff = colorImagePointOfHead.X - colorImagePointOfNeck.X;
            var ydiff = colorImagePointOfHead.Y - colorImagePointOfNeck.Y;
            var dist = Math.Sqrt((xdiff * xdiff) + (ydiff * ydiff));
            var rayon = dist / 2;

            this.headEllipse.Width = this.headEllipse.Height = dist;
            Canvas.SetLeft(this.headEllipse, colorImagePointOfHead.X - rayon);
            Canvas.SetTop(this.headEllipse, colorImagePointOfHead.Y - rayon);
        }

        private void DrawSkeletonId(ColorImagePoint colorImagePointOfHead)
        {
            Canvas.SetLeft(this.idLabel, colorImagePointOfHead.X);
            Canvas.SetTop(this.idLabel, colorImagePointOfHead.Y);
        }
    }
}
