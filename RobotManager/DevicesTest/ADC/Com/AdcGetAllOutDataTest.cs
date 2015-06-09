namespace Org.Cen.Devices.ADC.Com
{
    using NUnit.Framework;

    public class AdcGetAllOutDataTest
    {
        [Test]
        public void ShouldGenerateGetAdcValueOutData()
        {
            string expected = "dR";

            AdcGetAllOutData outData = new AdcGetAllOutData();
            string actual = outData.GetMessage();

            Assert.AreEqual(expected, actual);
        }
    }
}
