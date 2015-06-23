namespace Org.Cen.Devices.Navigation.Com
{
    using NUnit.Framework;

    public class NavigationLocationOutDataTest
    {
        [Test]
        public void ShouldGenerateNavigationLocationReadOutData()
        {
            string expected = "Nl1234";

            NavigationLocationReadOutData outData = new NavigationLocationReadOutData(0x1234);

            string actual = outData.GetMessage();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldGenerateNavigationLocationWriteOutData()
        {
            string expected = "NL41000000-0001-0002";

            NavigationLocationWriteOutData outData = new NavigationLocationWriteOutData("A", 1, 2);

            string actual = outData.GetMessage();
            Assert.AreEqual(expected, actual);
        }
    }
}
