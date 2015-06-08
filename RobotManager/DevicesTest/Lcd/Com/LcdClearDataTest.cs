namespace Org.Cen.Devices.Lcd.Com
{
    using NUnit.Framework;

    public class LcdClearDataTest
    {
        [Test]
        public void ShouldGenerateLcdClearData()
        {
            string expected = "Lc";
            LcdClearData outData = new LcdClearData();
            string actual = outData.GetMessage();
            Assert.AreEqual(expected, actual);
        }
    }
}