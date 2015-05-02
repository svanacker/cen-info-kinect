namespace Org.Cen.Devices.Eeprom.Com
{
    using Motion.Position.Com;
    using NUnit.Framework;

    public class EepromReadInDataDecoderTest
    {
        [Test]
        public void ShouldDecodeEepromReadOutDataDecoder()
        {
            string data = "aEr56";
            EepromReadInDataDecoder decoder = new EepromReadInDataDecoder();

            EepromReadInData inData = (EepromReadInData) decoder.Decode(data);

            Assert.AreEqual(data.Length, decoder.GetDataLength(EepromReadInData.HEADER));
        }
    }
}