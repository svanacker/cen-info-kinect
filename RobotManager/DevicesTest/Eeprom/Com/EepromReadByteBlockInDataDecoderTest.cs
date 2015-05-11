namespace Org.Cen.Devices.Eeprom.Com
{
    using NUnit.Framework;

    public class EepromReadByteBlockInDataDecoderTest
    {
        [Test]
        public void ShouldDecodeEepromReadByteBlockOutDataDecoder()
        {
            string data = "aEb12-34-56-78-90-12-34-56";
            EepromReadByteBlockInDataDecoder decoder = new EepromReadByteBlockInDataDecoder();

            EepromReadByteBlockInData inData = (EepromReadByteBlockInData)decoder.Decode(data);

            char[] values = inData.Values;

            Assert.AreEqual(0x12, values[0]);
            Assert.AreEqual(0x34, values[1]);
            Assert.AreEqual(0x56, values[2]);
            Assert.AreEqual(0x78, values[3]);
            Assert.AreEqual(0x90, values[4]);
            Assert.AreEqual(0x12, values[5]);
            Assert.AreEqual(0x34, values[6]);
            Assert.AreEqual(0x56, values[7]);
             
            Assert.AreEqual(data.Length, decoder.GetDataLength(EepromReadByteBlockInData.HEADER));
        }
    }
}