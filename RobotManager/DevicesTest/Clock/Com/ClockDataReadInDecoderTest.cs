namespace Org.Cen.Devices.Clock.Com
{
    using NUnit.Framework;
    
    public class ClockDataReadInDecoderTest
    {
        [Test]
        public void ShouldDecodeClockDataDecoder()
        {
            string data = "akr11:15:2E 04/05/0F";

            ClockReadInDataDecoder decoder = new ClockReadInDataDecoder();
            ClockReadInData inData = (ClockReadInData)decoder.Decode(data);
            ClockData clockData = inData.Clock;

            int hour = clockData.Hour;
            int minute = clockData.Minute;
            int second = clockData.Second;
            int day = clockData.Day;
            int month = clockData.Month;
            int year = clockData.Year;

            Assert.AreEqual(0x11, hour);
            Assert.AreEqual(0x15, minute);
            Assert.AreEqual(0x2E, second);
            Assert.AreEqual(0x04, day);
            Assert.AreEqual(0x05, month);
            Assert.AreEqual(0x0F, year);

            Assert.AreEqual(data.Length, decoder.GetDataLength(ClockReadInData.HEADER));
        }
    }
}
