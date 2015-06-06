namespace Org.Cen.Devices.System
{
    using Com;
    using NUnit.Framework;

    public class SystemOutDataTest
    {
        [Test]
        public void Should_SystemUsageOutData_Be_Ok()
        {
            SystemUsageOutData outData = new SystemUsageOutData();
            string message = outData.GetMessage();
            Assert.AreEqual("Su", message);
        }

        [Test]
        public void Should_SystemGetLastError_Be_Ok()
        {
            SystemGetLastErrorOutData outData = new SystemGetLastErrorOutData();
            string message = outData.GetMessage();
            Assert.AreEqual("Se", message);
        }

        [Test]
        public void Should_SystemClearLastError_Be_Ok()
        {
            SystemClearLastErrorOutData outData = new SystemClearLastErrorOutData();
            string message = outData.GetMessage();
            Assert.AreEqual("SE", message);
        }
    }
}
