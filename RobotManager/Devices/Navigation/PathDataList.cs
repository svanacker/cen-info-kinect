namespace Org.Cen.Devices.Navigation
{
    using global::System.Collections.Generic;

    public class PathDataList : IEnumerable<PathData>
    {
        private readonly IList<PathData> list;

        public int Count { get { return list.Count; } }

        public PathDataList()
        {
            list = new List<PathData>();
        }

        public void AddPathData(PathData pathData)
        {
            list.Add(pathData);
        }

        public IEnumerator<PathData> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
