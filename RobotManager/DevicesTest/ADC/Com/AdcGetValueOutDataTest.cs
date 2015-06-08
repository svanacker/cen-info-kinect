namespace Org.Cen.Devices.ADC.Com
{
    using NUnit.Framework;

    public class AdcGetValueOutDataTest
    {
        [Test]
        public void ShouldGenerateGetAdcValueOutData()
        {
            int address = 05; //index de l'adresse que l'on veut lire

            string expected = "dr05";

            AdcGetValueOutData outData = new AdcGetValueOutData(address);
            string actual = outData.GetMessage();
            Assert.AreEqual(expected, actual);
        }
    }
}
