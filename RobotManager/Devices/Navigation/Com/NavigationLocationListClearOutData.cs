namespace Org.Cen.Devices.Navigation.Com
{
    using Communication.Out;

    public class NavigationLocationListClearOutData : OutData
    {
        public const string HEADER = "Nd";

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
