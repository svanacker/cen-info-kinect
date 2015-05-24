namespace Org.Cen.Devices.Clock.Com
{
    using NUnit.Framework;

    public class ClockWriteHourOutDataTest
    {

        [Test]
        public void ShouldWriteClockHourOutDataGetMessage()
        {
            int hourExpected = 0x14;
            int minuteExpected = 0x28;
            int secondExpected = 0x05;
            
            ClockWriteHourOutData writeData = new ClockWriteHourOutData(hourExpected, minuteExpected, secondExpected);
            string result = writeData.GetMessage();

            Assert.AreEqual("kh142805", result);
        }
    }
}
