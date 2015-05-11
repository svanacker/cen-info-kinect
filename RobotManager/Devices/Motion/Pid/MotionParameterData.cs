namespace Org.Cen.Devices.Pid
{
    public class MotionParameterData
    {
        public int Acceleration { get; set; }
        public int Speed { get; set; }
        public int SpeedMax { get; set; }
        public int Time1 { get; set; }
        public int Time2 { get; set; }
        public int Time3 { get; set; }
        public int Position1 { get; set; }
        public int Position2 { get; set; }
        public int NextPosition { get; set; }

        // TODO
        // profileType
        // motionParameterType
        // pidType
    }
}
