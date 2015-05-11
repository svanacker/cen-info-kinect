namespace Org.Cen.Devices.Eeprom.Com
{
    using NUnit.Framework;

    public class EepromWriteByteBlockOutDataTest
    {
        [Test]
        public void ShouldGenerateEepromWriteByteBlockOutData()
        {
            string expected = "EB1234-56-78-90-12";

            char[] values = new char[] {(char) 0x56, (char) 0x78, (char) 0x90, (char) 0x12};
            EepromWriteByteBlockOutData outData = new EepromWriteByteBlockOutData(0x1234, values);
            string actual = outData.getMessage();
            Assert.AreEqual(expected, actual);
        }
    }
}
