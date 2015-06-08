namespace Org.Cen.Devices.ADC
{
    using NUnit.Framework;

    class AdcGetAllTest
    {
        [Test]
        public void ShouldGenerateGetAdcllOut()
        {
            string expected = "dR";

            AdcGetAll outData = new AdcGetAll();
            string actual = outData.GetMessage();

            Assert.AreEqual(expected, actual);
        }
    }
}
