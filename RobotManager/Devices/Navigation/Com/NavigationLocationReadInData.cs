namespace Org.Cen.Devices.Navigation.Com
{
    using Communication.In;

    public class NavigationLocationReadInData : InData
    {
        public const string HEADER = "Nl";

        public Location NavigationLocation { get; private set; }

        public NavigationLocationReadInData(Location location)
        {
            NavigationLocation = location;
        }
    }
}
