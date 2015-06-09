namespace Org.Cen.Devices.ADC.Com
{
    using NUnit.Framework;

    class AdcGetAllInDataDecoderTest
    {
        [Test]
        public void ShouldDecodeAdcGetAllInDataDecoder()
        {
            string data = "adrAB07-ED98-9A00-ABCD-0005-0909";

            AdcGetAllInDataDecoder decoder = new AdcGetAllInDataDecoder();
            AdcGetAllInData inData = (AdcGetAllInData)decoder.Decode(data);

            int actual0 = inData.DigitalValues[0];
            int actual1 = inData.DigitalValues[1];
            int actual2 = inData.DigitalValues[2];
            int actual3 = inData.DigitalValues[3];
            int actual4 = inData.DigitalValues[4];
            int actual5 = inData.DigitalValues[5];

            Assert.AreEqual(0xAB07, actual0);
            Assert.AreEqual(0xED98, actual1);
            Assert.AreEqual(0x9A00, actual2);
            Assert.AreEqual(0xABCD, actual3);
            Assert.AreEqual(0x0005, actual4);
            Assert.AreEqual(0x0909, actual5);

            Assert.AreEqual(data.Length, decoder.GetDataLength(AdcGetValueInData.HEADER));
        }
    }
}
