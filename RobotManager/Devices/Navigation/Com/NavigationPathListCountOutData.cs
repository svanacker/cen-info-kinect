namespace Org.Cen.Devices.Navigation.Com
{
    using Communication.Out;

    public class NavigationPathListCountOutData : OutData
    {
        public const string HEADER = "NC";

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
