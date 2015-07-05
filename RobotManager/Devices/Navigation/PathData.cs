namespace Org.Cen.Devices.Navigation
{
    using global::System.Xml.Serialization;

    public class PathData
    {
        /** first point (with name). */
        [XmlAttribute("locationName1")]
        public string LocationName1 { get; set; }

        /** second point (with name). */
        [XmlAttribute("locationName2")]
        public string LocationName2 { get; set; }

        /** Distance of the control point P0-P1 in cm. */
        [XmlAttribute("cp1")]
        public int ControlPointDistance1 { get; set; }

        /** Distance of the control point P1->P3 in cm. */
        [XmlAttribute("cp2")]
        public int ControlPointDistance2 { get; set; }

        /** Cost of the path. */
        [XmlAttribute("cost")]
        public int Cost { get; set; }

        /** angle1 (when at P0) in decidegree. */
        [XmlAttribute("angle1")]
        public int Angle1 { get; set; }

        /** angle2 (when at P3) in decidegree. */
        [XmlAttribute("angle2")]
        public int Angle2 { get; set; }

        /** AccelerationFactor factor (min = 1, max = 16). */
        [XmlAttribute("aFactor")]
        public int AccelerationFactor { get; set; }

        /** Speed factor (min = 1, max = 16). */
        [XmlAttribute("sFactor")]
        public int SpeedFactor { get; set; }

        /** When reversed, the path must be done backward. */
        [XmlAttribute("backward")]
        public bool MustGoBackward { get; set; }

        /**
         * For serialization only !
         */
        public PathData()
        {

        }

        public PathData(string locationName1, string locationName2, int cost, int controlPointDistance1
            , int controlPointDistance2, int angle1, int angle2, int accelerationFactor, int speedFactor,
            bool mustGoBackward)
        {
            LocationName1 = locationName1;
            LocationName2 = locationName2;
            Cost = cost;
            ControlPointDistance1 = controlPointDistance1;
            ControlPointDistance2 = controlPointDistance2;
            Angle1 = angle1;
            Angle2 = angle2;
            AccelerationFactor = accelerationFactor;
            SpeedFactor = speedFactor;
            MustGoBackward = mustGoBackward;
        }
    }
}
