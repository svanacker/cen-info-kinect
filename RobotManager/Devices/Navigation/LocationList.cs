namespace Org.Cen.Devices.Navigation
{
    using global::System.Collections.Generic;

    public class LocationList : IEnumerable<Location>
    {
        private readonly IList<Location> list;

        public int Count { get { return list.Count; } }

        public LocationList()
        {
            list = new List<Location>();
        }

        public Location AddLocation(string name, int x, int y)
        {
            Location result = new Location(name, x, y);
            list.Add(result);
            return result;
        }

        public IEnumerator<Location> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
