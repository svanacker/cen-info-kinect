namespace Org.Cen.Devices.Navigation
{
    using global::System;
    using global::System.Xml.Serialization;

    public class Location
    {
        const int LocationNameMaxLength = 4;

        /// <summary>
        /// Name of the point
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// The coordinates in x.
        /// </summary>
        [XmlAttribute("x")]
        public int X { get; set; }

        /// <summary>
        /// The coordinates in y.
        /// </summary>
        [XmlAttribute("y")]
        public int Y { get; set; }

        /// <summary>
        /// For Serialization only ! Do not use.
        /// </summary>
        public Location()
        {

        }
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
