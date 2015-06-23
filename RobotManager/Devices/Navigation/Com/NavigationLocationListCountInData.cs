namespace Org.Cen.Devices.Navigation.Com
{
    using Communication.In;

    public class NavigationLocationListCountInData : InData
    {
        public const string HEADER = "Nd";

        public int Count { get; private set; }

        public NavigationLocationListCountInData(int count)
        {
            Count = count;
        }
    }
}
