namespace Org.Cen.Devices.Robot.Start.Com
{
    using Eeprom.Com;
    using NUnit.Framework;

    public class EepromReadOutDataTest
    {
        [Test]
        public void ShouldGenerateEepromReadOutData()
        {
            string expected = "Er0012";

            EepromReadOutData outData = new EepromReadOutData(0x12);
            string actual = outData.getMessage();
            Assert.AreEqual(expected, actual);
        }
    }
}
