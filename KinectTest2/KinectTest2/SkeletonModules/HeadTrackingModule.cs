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
        private readonly Ellipse headEllipse = new Ellipse { StrokeThickness = 3 };
        private readonly Rectangle leftHand = new Rectangle { StrokeThickness = 3, Visibility = Visibility.Hidden };
        private readonly Rectangle rightHand = new Rectangle { StrokeThickness = 3, Visibility = Visibility.Hidden };
        private readonly Label idLabel = new Label();

        private KinectSensor kinect;
        private MainWindow window;

        public HeadTrackingModule(KinectSensor kinect, MainWindow window, int skeletonId, Brush drawingColor)
        {
            this.kinect = kinect;
            this.window = window;

            this.headEllipse.Stroke = drawingColor;
            this.window.ImageCanvas.Children.Add(this.headEllipse);

            this.leftHand.Stroke = drawingColor;
            this.window.ImageCanvas.Children.Add(this.leftHand);

            this.rightHand.Stroke = drawingColor;
            this.window.ImageCanvas.Children.Add(this.rightHand);

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
            this.window.ImageCanvas.Children.Remove(this.leftHand);
            this.window.ImageCanvas.Children.Remove(this.rightHand);
            this.window.ImageCanvas.Children.Remove(this.idLabel);
        }

        public void Follow(Skeleton skeleton, int skeletonIndex)
        {
            var headLoc = skeleton.Joints[JointType.Head].Position;
            var neckLoc = skeleton.Joints[JointType.ShoulderCenter].Position;
            var coordMapper = this.kinect.CoordinateMapper;
            var colorImagePointOfHead = coordMapper.MapSkeletonPointToColorPoint(headLoc, ColorImageFormat.RgbResolution640x480Fps30);
            var colorImagePointOfNeck = coordMapper.MapSkeletonPointToColorPoint(neckLoc, ColorImageFormat.RgbResolution640x480Fps30);
            this.DrawEllipse(colorImagePointOfHead, colorImagePointOfNeck);

            this.idLabel.Content = string.Format("{0}/{1}", skeleton.TrackingId, skeletonIndex);
            this.DrawSkeletonId(colorImagePointOfHead);

            this.FollowHand(skeleton.Joints[JointType.HandLeft], this.leftHand);
            this.FollowHand(skeleton.Joints[JointType.HandRight], this.rightHand);
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

        private void FollowHand(Joint handJoint, Rectangle handRectangle)
        {
            if (handJoint.TrackingState == JointTrackingState.NotTracked)
            {
                handRectangle.Visibility = Visibility.Hidden;
            }
            else
            {
                var coordMapper = this.kinect.CoordinateMapper;
                var colorImagePointOfHand = coordMapper.MapSkeletonPointToColorPoint(handJoint.Position, ColorImageFormat.RgbResolution640x480Fps30);

                handRectangle.Width = 20;
                handRectangle.Height = 20;
                Canvas.SetLeft(handRectangle, colorImagePointOfHand.X - 10);
                Canvas.SetTop(handRectangle, colorImagePointOfHand.Y - 10);
                handRectangle.Visibility = Visibility.Visible;
            }
        }
    }
}
