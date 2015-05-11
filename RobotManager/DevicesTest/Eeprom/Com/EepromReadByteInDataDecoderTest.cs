namespace Org.Cen.Devices.Eeprom.Com
{
    using Motion.Position.Com;
    using NUnit.Framework;

    public class EepromReadByteInDataDecoderTest
    {
        [Test]
        public void ShouldDecodeEepromReadOutDataDecoder()
        {
            string data = "aEr56";
            EepromReadByteInDataDecoder decoder = new EepromReadByteInDataDecoder();

            EepromReadByteInData inData = (EepromReadByteInData) decoder.Decode(data);

            Assert.AreEqual(data.Length, decoder.GetDataLength(EepromReadByteInData.HEADER));
        }
    }
}