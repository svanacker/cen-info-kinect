namespace Org.Cen.Devices.Navigation.Com
{
    using NUnit.Framework;

    public class NavigationLocationInDataDecoderTest
    {
        [Test]
        public void ShouldDecodeNavigationLocationCountInData()
        {
            string data = "aNc0123";

            NavigationLocationListCountInDataDecoder decoder = new NavigationLocationListCountInDataDecoder();
            NavigationLocationListCountInData inData = (NavigationLocationListCountInData)decoder.Decode(data);

            int actualCount = inData.Count;
            Assert.AreEqual(0x0123, actualCount);

            Assert.AreEqual(data.Length, decoder.GetDataLength(NavigationLocationListCountInData.HEADER));
        }
    }
}
