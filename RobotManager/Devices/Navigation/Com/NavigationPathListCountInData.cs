namespace Org.Cen.Devices.Navigation.Com
{
    using Communication.In;

    public class NavigationPathListCountInData : InData
    {
        public const string HEADER = "ND";

        public int Count { get; private set; }

        public NavigationPathListCountInData(int count)
        {
            Count = count;
        }
    }
}
