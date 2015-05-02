namespace Org.Cen.Devices.Eeprom.Com
{
    using NUnit.Framework;

    public class EepromReadOutDataTest
    {
        [Test]
        public void ShouldGenerateEepromReadOutData()
        {
            string expected = "Er1234";

            EepromReadOutData outData = new EepromReadOutData(0x1234);
            string actual = outData.getMessage();
            Assert.AreEqual(expected, actual);
        }
    }
}
