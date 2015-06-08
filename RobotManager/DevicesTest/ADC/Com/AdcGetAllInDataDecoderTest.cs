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

            int actual0 = inData.ValueDigital0;
            int actual1 = inData.ValueDigital1;
            int actual2 = inData.ValueDigital2;
            int actual3 = inData.ValueDigital3;
            int actual4 = inData.ValueDigital4;
            int actual5 = inData.ValueDigital5;

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
