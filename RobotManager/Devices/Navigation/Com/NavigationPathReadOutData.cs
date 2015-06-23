namespace Org.Cen.Devices.Navigation.Com
{
    using Communication.Out;
    using Communication.Utils;

    public class NavigationPathReadOutData : OutData
    {
        public const string HEADER = "Np";

        public int Index { get; private set; }

        public NavigationPathReadOutData(int index)
        {
            Index = index;
        }

        public override string GetArguments()
        {
            return DataParserUtils.format(Index, 4);
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
