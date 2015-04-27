namespace Devices.Motion.Position
{
    /**
     * Encapsulation of the both wheel position.
     */
    public class WheelPositionData
    {
        public long LeftPosition { get; set; }
        public long RightPosition { get; set; }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{left=" + LeftPosition + ", right=" + RightPosition + "}";
        }
    }
}

