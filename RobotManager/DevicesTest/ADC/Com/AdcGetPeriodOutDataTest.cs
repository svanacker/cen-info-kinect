namespace Org.Cen.Devices.ADC.Com
{
    using NUnit.Framework;

    public class AdcGetPeriodOutDataTest
    {
        [Test]
        public void ShouldGenerateGetAdcPeriodeOutData()
        {
            int adcIndex = 0x05;
            int sampleCount = 0x0A;
            int secondeBetweenRead = 0x02;

            AdcGetPeriodOutData outData = new AdcGetPeriodOutData(adcIndex, sampleCount, secondeBetweenRead);
            string actual = outData.GetMessage();


            string expected = "ds05-0A-02";
            Assert.AreEqual(expected, actual);
        }
    }
}
