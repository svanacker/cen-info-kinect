namespace Org.Cen.Devices.Motion.Position.Com
{
    using Cen.Com.In;
    using Org.Com.Devices.Motion.Position;

    public class RobotPositionReadInData : InData
    {
        public const string HEADER = "nr";

        public RobotPosition Position { get; private set; }

        public RobotPositionReadInData(RobotPosition position)
            : base()
        {
            this.Position = position;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{RobotPosition=" + Position + "}";
        }
    }
}
