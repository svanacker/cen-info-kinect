namespace Org.Cen.Devices.Robot.Start.Com
{
    using Cen.Com.In;
    using Communication.In;
    using Robot;

    public class StartMatchReadPositionInData : InData
    {
        public const string HEADER = "!p";

        public MatchSide Side { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int AngleDeciDegree { get; private set; }

        public StartMatchReadPositionInData(MatchSide side, int x, int y, int angleDeciDegree)
            : base()
        {
            Side = side;
            X = x;
            Y = y;
            AngleDeciDegree = angleDeciDegree;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{x=" + X + ", y=" + Y + ", angle=" + AngleDeciDegree + "}";
        }
    }
}
