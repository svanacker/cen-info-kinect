namespace Org.Cen.Devices.Motion.Simulation
{
    public class MotionSimulationData
    {
        public bool Motors { get; private set; }
        public bool Coders { get; private set; }
        public bool Position { get; private set; }

        public MotionSimulationData(bool motors, bool coders, bool position)
        {
            Motors = motors;
            Coders = coders;
            Position = position;
        }
    }
}
