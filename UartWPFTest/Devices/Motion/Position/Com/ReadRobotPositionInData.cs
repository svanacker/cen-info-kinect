namespace Org.Cen.Devices.Motion.Position.Com
{
    using Cen.Com.In;
    using Org.Com.Devices.Motion.Position;

    public class ReadRobotPositionInData : InData
    {
        public const string HEADER = "nr";

        public RobotPosition Position { get; private set; }

        public ReadRobotPositionInData(RobotPosition position)
            : base()
        {
            this.Position = position;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{position=" + Position + "}";
        }
    }
}
