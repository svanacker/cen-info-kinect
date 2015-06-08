namespace Org.Cen.Devices.ADC.Com
{
    using NUnit.Framework;

    class AdcGetAllTest
    {
        [Test]
        public void ShouldGenerateGetAdcllOutData()
        {
            string expected = "dR";

            AdcGetAll outData = new AdcGetAll();
            string actual = outData.GetMessage();

            Assert.AreEqual(expected, actual);
        }
    }
}
