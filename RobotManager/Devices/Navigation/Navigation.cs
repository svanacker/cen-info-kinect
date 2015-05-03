namespace Org.Cen.Devices.Navigation
{
    public sealed class Navigation
    {
        private static Navigation _instance;

        public static Navigation Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Navigation();
                }
                return _instance;
            }
        }

        public LocationList LocationList { get; private set; }
        public PathDataList PathDataList { get; private set; }

        private Navigation()
        {
            LocationList = new LocationList();
            PathDataList = new PathDataList();
        }
    }
}
