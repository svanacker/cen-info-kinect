namespace Org.Cen.Devices.Navigation
{
    public class PathData
    {
        /** first point (with name). */
        public Location Location1 { get; private set; }

        /** second point (with name). */
        public Location Location2 { get; private set; }

        /** Cost of the path. */
        public uint Cost { get; private set; }

        /** Distance of the control point P0-P1 in cm. */
        public sbyte ControlPointDistance1 { get; private set; }

        /** Distance of the control point P1->P3 in cm. */
        public sbyte ControlPointDistance2 { get; private set; }

        /** angle1 (when at P0) in decidegree. */
        public int Angle1 { get; private set; }

        /** angle2 (when at P3) in decidegree. */
        public int Angle2 { get; private set; }

        /** AccelerationFactor factor (min = 1, max = 16). */
        public byte AccelerationFactor { get; private set; }

        /** Speed factor (min = 1, max = 16). */
        public byte SpeedFactor { get; private set; }

        /** When reversed, the path must be done backward. */
        public bool MustGoBackward { get; private set; }

        public PathData(Location location1, Location location2, uint cost, sbyte controlPointDistance1
            , sbyte controlPointDistance2, int angle1, int angle2, byte accelerationFactor, byte speedFactor,
            bool mustGoBackward)
        {
            Location1 = location1;
            Location2 = location2;
            Cost = cost;
            ControlPointDistance1 = controlPointDistance1;
            ControlPointDistance2 = controlPointDistance2;
            Angle1 = angle1;
            Angle2 = angle2;
            AccelerationFactor = accelerationFactor;
            SpeedFactor = speedFactor;
            MustGoBackward = mustGoBackward;
        }
    }
}
