namespace Org.Cen.Devices.Lcd.Com
{
    using NUnit.Framework;

    public class LcdClearDataTest
    {
        [Test]
        public void ShouldGenerateLcdClearData()
        {
            string expected = "Lc";
            LcdClearOutData outData = new LcdClearOutData();
            string actual = outData.GetMessage();
            Assert.AreEqual(expected, actual);
        }
    }
}