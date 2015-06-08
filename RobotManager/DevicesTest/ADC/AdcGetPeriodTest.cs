namespace Org.Cen.Devices.ADC
{
    using NUnit.Framework;

    class AdcGetPeriodTest
    {
        [Test]
        public void ShouldGenerateGetAdcPeriodeOut()
        {
            int adcIndex = 05;
            int sampleCount = 05;
            int secondeBetweenRead = 02;

            string expected = "ds050502";

            AdcGetPeriod outData = new AdcGetPeriod(adcIndex, sampleCount, secondeBetweenRead);
            string actual = outData.GetMessage();

            Assert.AreEqual(expected, actual);

        }
    }
}
