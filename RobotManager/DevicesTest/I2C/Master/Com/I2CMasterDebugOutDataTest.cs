namespace Org.Cen.Devices.I2C.Master.Com
{
    using I2c.Master.Com;
    using NUnit.Framework;

    public class I2CMasterDebugOutDataTest
    {
        [Test]
        public void Should_I2CMasterDebugEnableOutData_Be_Ok()
        {
            I2CMasterDebugEnableOutData outData = new I2CMasterDebugEnableOutData(true);
            string message = outData.GetMessage();
            Assert.AreEqual("Ie1", message);
        }

        public void Should_I2CMasterWriteCharOutData_Be_Ok()
        {
            I2CMasterWriteCharOutData outData = new I2CMasterWriteCharOutData('A');
            string message = outData.GetMessage();
            Assert.AreEqual("Iw65", message);
        }
    }
}
