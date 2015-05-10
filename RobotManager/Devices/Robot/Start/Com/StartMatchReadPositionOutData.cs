namespace Org.Cen.Devices.Robot.Start.Com
{
    using Cen.Com.Out;
    using Communication.Utils;

    public class StartMatchReadPositionOutData : OutData
    {
        public const string HEADER = "!p";

        public MatchSide Side { get; private set; }

        public StartMatchReadPositionOutData(MatchSide side)
        {
            Side = side;
        }


        public override string getArguments()
        {
            string result = DataParserUtils.format((int)(Side), 2);
            return result;
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}
