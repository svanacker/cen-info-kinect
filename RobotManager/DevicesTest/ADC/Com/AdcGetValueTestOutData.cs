namespace Org.Cen.Devices.ADC.Com
{
    using NUnit.Framework;

    class AdcGetValueTest
    {
        [Test]
        public void ShouldGenerateGetAdcValueOutData()
        {
            int adr = 05; //index de l'adresse que l'on veut lire

            string expected = "dr05";

            AdcGetValue outData = new AdcGetValue(adr);
            string actual = outData.GetMessage();
            Assert.AreEqual(expected, actual);
        }
    }
}
