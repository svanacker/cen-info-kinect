namespace Org.Cen.Devices.Battery.Com
{
    using NUnit.Framework;

    public class BatteryInDataDecoderTest
    {
        [Test]
        public void Should_Decode_BatteryReadInData()
        {
            string data = "abr1234";

            BatteryReadInDataDecoder decoder = new BatteryReadInDataDecoder();
            BatteryReadInData inData = (BatteryReadInData)decoder.Decode(data);

            Assert.AreEqual(0x1234, inData.Value);

            int length = decoder.GetDataLength(null);
            Assert.AreEqual(length, data.Length);
        }
    }
}
