namespace Org.Cen.Devices.Navigation.Com
{
    using Communication.Out;

    public class NavigationLocationReadCountOutData : OutData
    {
        public const string HEADER = "Nc";

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
