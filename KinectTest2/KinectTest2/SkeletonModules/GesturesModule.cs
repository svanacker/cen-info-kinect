namespace KinectTest2.SkeletonModules
{
    using System.Windows;

    using Kinect.Toolbox;

    using Microsoft.Kinect;

    public class GesturesModule : ISkeletonModule
    {
        private KinectSensor kinect;
        private MainWindow window;

        private SwipeGestureDetector leftHandSwipeGestureDetector;
        private SwipeGestureDetector rightHandSwipeGestureDetector;

        public GesturesModule(KinectSensor kinect, MainWindow window)
        {
            this.kinect = kinect;
            this.window = window;

            this.leftHandSwipeGestureDetector = new SwipeGestureDetector();
            this.leftHandSwipeGestureDetector.OnGestureDetected += this.leftHandSwipeGestureDetector_OnGestureDetected;

            this.rightHandSwipeGestureDetector = new SwipeGestureDetector();
            this.rightHandSwipeGestureDetector.OnGestureDetected += this.rightHandSwipeGestureDetector_OnGestureDetected;
        }

        public void Dispose()
        {
            this.kinect = null;

            this.leftHandSwipeGestureDetector.OnGestureDetected -= this.leftHandSwipeGestureDetector_OnGestureDetected;
            this.rightHandSwipeGestureDetector.OnGestureDetected -= this.rightHandSwipeGestureDetector_OnGestureDetected;
        }

        public void Follow(Skeleton skeleton, int skeletonIndex)
        {
            this.leftHandSwipeGestureDetector.Add(skeleton.Joints[JointType.HandLeft].Position, this.kinect);
            this.rightHandSwipeGestureDetector.Add(skeleton.Joints[JointType.HandRight].Position, this.kinect);
        }

        private void leftHandSwipeGestureDetector_OnGestureDetected(string gestureName)
        {
            switch (gestureName)
            {
                case "SwipeToRight":
                    this.window.LeftRectangle.Visibility = Visibility.Visible;
                    break;
                case "SwipeToLeft":
                    this.window.LeftRectangle.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void rightHandSwipeGestureDetector_OnGestureDetected(string gestureName)
        {
            switch (gestureName)
            {
                case "SwipeToRight":
                    this.window.RightRectangle.Visibility = Visibility.Hidden;
                    break;
                case "SwipeToLeft":
                    this.window.RightRectangle.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}