namespace KinectTest2.SkeletonModules
{
    using System;

    using Microsoft.Kinect;

    public interface ISkeletonModule : IDisposable
    {
        void Follow(Skeleton skeleton, int skeletonIndex);
    }
}