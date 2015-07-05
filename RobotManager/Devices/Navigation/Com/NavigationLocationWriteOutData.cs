namespace Org.Cen.Devices.Navigation.Com
{
    using Communication.Out;
    using Communication.Utils;
    using global::System.Text;

    public class NavigationPathWriteOutData : OutData
    {
        public const string HEADER = "NP";

        public PathData Path { get; private set; }

        public NavigationPathWriteOutData(PathData pathData)
        {
            Path = pathData;
        }

        public override string GetArguments()
        {
            StringBuilder s = new StringBuilder();

            s.Append(DataParserUtils.FormatFixedCharArray(Path.LocationName1));
            s.Append("-");
            s.Append(DataParserUtils.FormatFixedCharArray(Path.LocationName2));
            s.Append("-");
            s.Append(DataParserUtils.format(Path.Cost, 4));
            s.Append("-");
            s.Append(DataParserUtils.format(Path.ControlPointDistance1, 4));
            s.Append("-");
            s.Append(DataParserUtils.format(Path.ControlPointDistance2, 4));
            s.Append("-");
            s.Append(DataParserUtils.format(Path.Angle1, 4));
            s.Append("-");
            s.Append(DataParserUtils.format(Path.Angle2, 4));
            s.Append("-");
            s.Append(DataParserUtils.format(Path.AccelerationFactor, 2));
            s.Append("-");
            s.Append(DataParserUtils.format(Path.SpeedFactor, 2));
            s.Append("-");
            s.Append(DataParserUtils.format(Path.MustGoBackward));

            string result = s.ToString();
            return result;
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
