namespace Org.Cen.Devices.Eeprom.Com
{
    using NUnit.Framework;

    public class EepromWriteOutDataTest
    {
        [Test]
        public void ShouldGenerateEepromWriteOutData()
        {
            string expected = "Ew1234-56";

            EepromWriteOutData outData = new EepromWriteOutData(0x1234, 0x56);
            string actual = outData.getMessage();
            Assert.AreEqual(expected, actual);
        }
    }
}
