namespace KinectTest2
{
    using Microsoft.Kinect;

    public interface IKinectModule
    {
        void Start(KinectSensor kinect);

        void Stop();
    }
}
