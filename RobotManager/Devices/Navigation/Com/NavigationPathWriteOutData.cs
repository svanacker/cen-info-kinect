namespace Org.Cen.Devices.Navigation.Com
{
    using Communication.Out;
    using Communication.Utils;
    using global::System.Text;

    public class NavigationLocationWriteOutData : OutData
    {
        public const string HEADER = "NL";

        public Location NavigationLocation { get; private set; }

        public NavigationLocationWriteOutData(string name, int x, int y)
        {
            NavigationLocation = new Location(name, x, y);
        }

        public override string GetArguments()
        {
            StringBuilder s = new StringBuilder();

            s.Append(DataParserUtils.FormatFixedCharArray(NavigationLocation.Name));
            s.Append("-");
            s.Append(DataParserUtils.format(NavigationLocation.X, 4));
            s.Append("-");
            s.Append(DataParserUtils.format(NavigationLocation.Y, 4));

            string result = s.ToString();
            return result;
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
