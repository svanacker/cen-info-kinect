namespace Org.Cen.RobotManager
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using Devices.Navigation;
    using NUnit.Framework;

    public class SerializationTest
    {
        [Test]
        public void Should_Serialize_Location_And_Path()
        {
            Location locationA = new Location("A", 1, 2);
            Location locationB = new Location("B", 3, 4);

            PathData pathData = new PathData("A", "B", 1, 20, 20, 4, 5, 1, 1, false);

            Navigation navigation = new Navigation();
            navigation.PathDataList.Add(pathData);

            XmlSerializer serializer = new XmlSerializer(navigation.GetType());
            string filename = "c:\\temp\\test.xml";
            using (StreamWriter sw = new System.IO.StreamWriter(filename))
            {
                serializer.Serialize(sw, navigation);
            }

            // Reload values
            using (StreamReader rd = new StreamReader(filename))
            {
                Navigation navigation2 = serializer.Deserialize(rd) as Navigation;
                PathDataList pathDataList = navigation2.PathDataList;
                Assert.AreEqual(pathDataList.PathCollection[0].LocationName1, "A");
            }
        }
        
    }
}
