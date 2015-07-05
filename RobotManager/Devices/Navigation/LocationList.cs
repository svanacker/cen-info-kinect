namespace Org.Cen.Devices.Navigation
{
    using global::System.Collections.Generic;

    public class LocationList : IEnumerable<Location>
    {
        public IList<Location> Elements { get; set; }

        public int Count { get { return Elements.Count; } }

        public LocationList()
        {
            Elements = new List<Location>();
        }

        public void Add(Location location)
        {
            Elements.Add(location);
        }

        public Location Add(string name, int x, int y)
        {
            Location result = new Location(name, x, y);
            Elements.Add(result);
            return result;
        }

        public IEnumerator<Location> GetEnumerator()
        {
            return Elements.GetEnumerator();
        }

        global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
