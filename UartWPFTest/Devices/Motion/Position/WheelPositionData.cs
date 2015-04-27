namespace Devices.Motion.Position
{
    /**
     * Encapsulation of the both wheel position.
     */
    public class WheelPositionData
    {
        public int LeftPosition { get; set; }
        public int RightPosition { get; set; }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{left=" + LeftPosition + ", right=" + RightPosition + "}";
        }
    }
}

