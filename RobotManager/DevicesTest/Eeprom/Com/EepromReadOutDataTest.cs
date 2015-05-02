namespace Org.Cen.Devices.Eeprom.Com
{
    using NUnit.Framework;

    public class EepromReadOutDataTest
    {
        [Test]
        public void ShouldGenerateEepromReadByteOutData()
        {
            string expected = "Er1234";

            EepromReadByteOutData outData = new EepromReadByteOutData(0x1234);
            string actual = outData.getMessage();
            Assert.AreEqual(expected, actual);
        }
    }
}
