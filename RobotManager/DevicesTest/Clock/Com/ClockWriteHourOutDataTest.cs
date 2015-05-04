namespace Org.Cen.Devices.Clock.Com
{
    using NUnit.Framework;
    class ClockWriteHourOutDataTest
    {
        [Test]
        public void ShouldWriteClockHourOutData()
        {
            int hourExpected = 0x14;
            int minuteExpected = 0x28;
            int secondExpected = 0x05;

            ClockWriteHourOutData writeData = new ClockWriteHourOutData(hourExpected, minuteExpected, secondExpected);
            ClockData clockData = writeData.Clock;

            int hour = clockData.Hour;
            int minute = clockData.Minute;
            int second = clockData.Second;

            Assert.AreEqual(0x14, hour);
            Assert.AreEqual(0x28, minute);
            Assert.AreEqual(0x05, second);
        }
    }
}
