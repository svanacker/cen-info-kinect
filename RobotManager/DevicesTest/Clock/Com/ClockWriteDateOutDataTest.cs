namespace Org.Cen.Devices.Clock.Com
{
    using NUnit.Framework;

    public class ClockWriteDateOutDataTest
    {

        [Test]
        public void ShouldWriteClockDateDataGetMessage()
        {
            int dayExpected = 0x04;
            int monthExpected = 0x05;
            int yearExpected = 0x0F;

            ClockWriteDateOutData writeData = new ClockWriteDateOutData(dayExpected, monthExpected, yearExpected);
            string result = writeData.getMessage();

            Assert.AreEqual("kd04050F", result);
        }
    }
}
