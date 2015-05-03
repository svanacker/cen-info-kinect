namespace Org.Cen.Devices.Navigation
{
    using global::System;

    public class Location
    {
        const int LocationNameMaxLength = 4;

        /// <summary>
        /// Name of the point
        /// </summary>
        public string Name { get; private set; }
 
        /// <summary>
        /// The coordinates in x.
        /// </summary>
        public int X { get; private set; }
        
        /// <summary>
        /// The coordinates in y.
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Location(string name, int x, int y)
        {
            if (name.Length > LocationNameMaxLength)
            {
                throw new Exception("Location Name must not be more long than " + LocationNameMaxLength + " chars");
            }
            Name = name;
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return GetType().Name + "{name=" + Name + ", x=" + X + ", y=" + Y + "}";
        }
    }
}
