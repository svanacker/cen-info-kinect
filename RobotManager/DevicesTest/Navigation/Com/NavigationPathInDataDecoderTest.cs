namespace Org.Cen.Devices.Navigation.Com
{
    using NUnit.Framework;

    public class NavigationPathInDataDecoderTest
    {
        [Test]
        public void ShouldDecodeNavigationLocationCountInData()
        {
            string data = "aNC0123";

            NavigationPathListCountInDataDecoder decoder = new NavigationPathListCountInDataDecoder();
            NavigationPathListCountInData inData = (NavigationPathListCountInData)decoder.Decode(data);

            int actualCount = inData.Count;
            Assert.AreEqual(0x0123, actualCount);

            Assert.AreEqual(data.Length, decoder.GetDataLength(NavigationPathListCountInData.HEADER));
        }
    }
}
