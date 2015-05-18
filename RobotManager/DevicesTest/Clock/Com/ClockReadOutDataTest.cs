namespace Org.Cen.Devices.Clock.Com
{
    using NUnit.Framework;

    public class ClockReadOutDataTest
    {
        [Test]
        public void ShouldGenerateClockReadOutData()
        {
            string expected = "kr";

            ClockReadOutData outData = new ClockReadOutData();
            string actual = outData.getMessage();
            Assert.AreEqual(expected, actual);
        }
    }
}
