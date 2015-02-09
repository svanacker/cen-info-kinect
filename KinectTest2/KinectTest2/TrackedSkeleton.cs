namespace KinectTest2
{
    using System.Collections.Generic;

    using KinectTest2.SkeletonModules;

    public class TrackedSkeleton
    {
        public int TrackNumber { get; set; }

        public int SkeletonId { get; set; }

        public ISkeletonModule[] SkeletonModules { get; set; }
    }
}
