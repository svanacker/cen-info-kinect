namespace Org.Cen.Devices.Navigation.Com
{
    using global::System.IO;
    using NUnit.Framework;

    public class NavigationPathOutDataTest
    {
        [Test]
        public void ShouldGenerateNavigationLocationReadOutData()
        {
            string expected = "Np1234";

            NavigationPathReadOutData outData = new NavigationPathReadOutData(0x1234);

            string actual = outData.GetMessage();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldGenerateNavigationPathWriteOutData()
        {
            string expected = "NP41424344-45464748-1234-5678-0123-0234-0456-01-02-1";

            PathData pathData = new PathData("ABCD", "EFGH", 0x1234, 0x5678, 0x0123, 0x0234, 0x0456, 0x01, 0x02,
                true);

            NavigationPathWriteOutData outData = new NavigationPathWriteOutData(pathData);

            string actual = outData.GetMessage();
            Assert.AreEqual(expected, actual);
        }
    }
}
