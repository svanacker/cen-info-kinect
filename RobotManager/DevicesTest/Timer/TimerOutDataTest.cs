namespace Org.Cen.Devices.Timer
{
    using Com;
    using NUnit.Framework;

    public class TimerOutDataTest
    {
        [Test]
        public void Should_TimerReadCountOutData_Be_Ok()
        {
            TimerReadCountOutData outData = new TimerReadCountOutData();
            string message = outData.GetMessage();
            Assert.AreEqual("Vc", message);
        }

        [Test]
        public void Should_TimerIsTimeroutOutData_Be_Ok()
        {
            TimerReadIsTimeoutOutData outData = new TimerReadIsTimeoutOutData(0x12, 0x345678);
            string message = outData.GetMessage();
            Assert.AreEqual("Vt12-345678", message);
        }

        [Test]
        public void Should_TimerReadTimeSinceLastMarkOutData_Be_Ok()
        {
            TimerReadTimeSinceLastMarkOutData outData = new TimerReadTimeSinceLastMarkOutData(0x12);
            string message = outData.GetMessage();
            Assert.AreEqual("Vm12", message);
        }

        [Test]
        public void Should_TimerWriteEnableOutData_Be_Ok()
        {
            TimerWriteEnableOutData outData = new TimerWriteEnableOutData(0x12, true);
            string message = outData.GetMessage();
            Assert.AreEqual("Ve12-1", message);
        }

        [Test]
        public void Should_TimerWriteMarkOutData_Be_Ok()
        {
            TimerWriteMarkOutData outData = new TimerWriteMarkOutData(0x12);
            string message = outData.GetMessage();
            Assert.AreEqual("VM12", message);
        }

    }

}
