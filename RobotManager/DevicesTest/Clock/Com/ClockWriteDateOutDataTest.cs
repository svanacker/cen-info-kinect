using System.Diagnostics;

namespace Org.Cen.Devices.Clock.Com
{
    using NUnit.Framework;
    class ClockWriteDateOutDataTest
    {
        [Test]
        public void ShouldWriteClockDateData()
        {
            int dayExpected = 0x04;
            int monthExpected = 0x05;
            int yearExpected = 0x0F;

            ClockWriteDateOutData writeData = new ClockWriteDateOutData(dayExpected, monthExpected, yearExpected);
            ClockData clockData = writeData.Clock;

            int day = clockData.Day;
            int month = clockData.Month;
            int year = clockData.Year;

            Assert.AreEqual(0x04, day);
            Assert.AreEqual(0x05, month);
            Assert.AreEqual(0x0F, year);
        }
        [Test]
        public void ShouldWriteClockDateDataGetMessage()
        {
            //Header kd
            int dayExpected = 0x04;
            int monthExpected = 0x05;
            int yearExpected = 0x0F;
            //string expected kd04050F

            ClockWriteDateOutData writeData = new ClockWriteDateOutData(dayExpected, monthExpected, yearExpected);
            string result = writeData.getMessage();
            Debug.WriteLine(result);

            Assert.AreEqual("kd04050F", result);
        }
    }
}
