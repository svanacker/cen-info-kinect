namespace KinectTest2
{
    using System.Windows;

    using Kinect.Toolbox;

    using Microsoft.Kinect;

    public class GesturesModule
    {
        private MainWindow window;

        private KinectSensor kinect;
        private SwipeGestureDetector leftHandSwipeGestureDetector;
        private SwipeGestureDetector rightHandSwipeGestureDetector;

        public GesturesModule(MainWindow window)
        {
            this.window = window;
        }

        public void Start(KinectSensor kinect)
        {
            this.kinect = kinect;

            this.leftHandSwipeGestureDetector = new SwipeGestureDetector();
            this.leftHandSwipeGestureDetector.OnGestureDetected += leftHandSwipeGestureDetector_OnGestureDetected;

            this.rightHandSwipeGestureDetector = new SwipeGestureDetector();
            this.rightHandSwipeGestureDetector.OnGestureDetected += rightHandSwipeGestureDetector_OnGestureDetected;
        }

        public void Stop()
        {
            this.kinect = null;

            this.leftHandSwipeGestureDetector.OnGestureDetected -= leftHandSwipeGestureDetector_OnGestureDetected;
            this.rightHandSwipeGestureDetector.OnGestureDetected -= rightHandSwipeGestureDetector_OnGestureDetected;
        }

        public void Follow(Skeleton skeleton)
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