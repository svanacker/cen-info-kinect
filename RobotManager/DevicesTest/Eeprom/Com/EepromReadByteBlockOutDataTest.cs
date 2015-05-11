namespace Org.Cen.Devices.Eeprom.Com
{
    using NUnit.Framework;

    public class EepromReadByteBlockOutDataTest
    {
        [Test]
        public void ShouldGenerateEepromReadByteBlockOutData()
        {
            string expected = "Eb1234";

            EepromReadByteBlockOutData outData = new EepromReadByteBlockOutData(0x1234);
            string actual = outData.getMessage();
            Assert.AreEqual(expected, actual);
        }
    }
}
