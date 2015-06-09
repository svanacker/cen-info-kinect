namespace Org.Cen.Devices.ADC.Com
{
    using NUnit.Framework;

    class AdcGetValueInDataDecoderTest
    {
        [Test]
        public void ShouldDecodeAdcGetValueInDataDecoder()
        {
            string data = "adrA7B9";

            AdcGetValueInDataDecoder decoder = new AdcGetValueInDataDecoder();
            AdcGetValueInData inData = (AdcGetValueInData)decoder.Decode(data);

            int actual = inData.DigitalValue;

            Assert.AreEqual(0xA7B9, actual);
            Assert.AreEqual(data.Length, decoder.GetDataLength(AdcGetValueInData.HEADER));
        }
    }
}
