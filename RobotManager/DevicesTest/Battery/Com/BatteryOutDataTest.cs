namespace Org.Cen.Devices.Battery.Com
{
    using NUnit.Framework;

    public class BatteryOutDataTest
    {
        [Test]
        public void Should_BatteryReadOutData_Be_Ok()
        {
            BatteryReadOutData outData = new BatteryReadOutData();
            string message = outData.GetMessage();
            Assert.AreEqual("br", message);
        }
    }
}
