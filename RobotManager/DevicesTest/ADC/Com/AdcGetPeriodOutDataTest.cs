namespace Org.Cen.Devices.ADC.Com
{
    using NUnit.Framework;

    public class AdcGetPeriodOutDataTest
    {
        [Test]
        public void ShouldGenerateGetAdcPeriodeOutData()
        {
            int adcIndex = 05;
            int sampleCount = 05;
            int secondeBetweenRead = 02;

            string expected = "ds050502";

            AdcGetPeriodOutData outData = new AdcGetPeriodOutData(adcIndex, sampleCount, secondeBetweenRead);
            string actual = outData.GetMessage();

            Assert.AreEqual(expected, actual);
        }
    }
}
