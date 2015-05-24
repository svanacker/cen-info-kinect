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
            string actual = outData.GetMessage();
            Assert.AreEqual(expected, actual);
        }
    }
}
