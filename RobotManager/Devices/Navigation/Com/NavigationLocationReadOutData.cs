namespace Org.Cen.Devices.Navigation.Com
{
    using Communication.Out;
    using Communication.Utils;

    public class NavigationLocationReadOutData : OutData
    {
        public const string HEADER = "Nl";

        public int Index { get; private set; }

        public NavigationLocationReadOutData(int index)
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
