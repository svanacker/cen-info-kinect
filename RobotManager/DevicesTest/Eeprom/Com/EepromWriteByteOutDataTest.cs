namespace Org.Cen.Devices.Eeprom.Com
{
    using NUnit.Framework;

    public class EepromWriteByteOutDataTest
    {
        [Test]
        public void ShouldGenerateEepromWriteByteOutData()
        {
            string expected = "Ew1234-56";

            EepromWriteByteOutData outData = new EepromWriteByteOutData(0x1234, 0x56);
            string actual = outData.GetMessage();
            Assert.AreEqual(expected, actual);
        }
    }
}
