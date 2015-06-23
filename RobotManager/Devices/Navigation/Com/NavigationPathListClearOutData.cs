namespace Org.Cen.Devices.Navigation.Com
{
    using Communication.Out;

    public class NavigationPathListClearOutData : OutData
    {
        public const string HEADER = "ND";

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
