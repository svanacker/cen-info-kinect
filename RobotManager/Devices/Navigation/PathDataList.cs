namespace Org.Cen.Devices.Navigation
{
    using global::System.Collections.Generic;
    using global::System.Xml.Serialization;

    public class PathDataList : IEnumerable<PathData>
    {
        [XmlArray("PathCollection")]
        public IList<PathData> PathCollection { get; set; }

        public int Count { get { return PathCollection.Count; } }

        public PathDataList()
        {
            PathCollection = new List<PathData>();
        }

        public void Add(PathData pathData)
        {
            PathCollection.Add(pathData);
        }

        public IEnumerator<PathData> GetEnumerator()
        {
            return PathCollection.GetEnumerator();
        }

        global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
