namespace Org.Cen.Devices.Servo
{
    using Com;
    using NUnit.Framework;

    public class ServoOutDataTest
    {
        [Test]
        public void Should_ServoReadParametersOutData_Be_Ok()
        {
            ServoReadParametersOutData outData = new ServoReadParametersOutData(0x12);
            string message = outData.GetMessage();
            Assert.AreEqual("sr12", message);
        }

        [Test]
        public void Should_ServoWriteParametersOutData_Be_Ok()
        {
            ServoData servoData = new ServoData(0x12, 0x34, 0x5678);
            ServoWriteParametersOutData outData = new ServoWriteParametersOutData(servoData);
            string message = outData.GetMessage();
            Assert.AreEqual("sw12-34-5678", message);
        }
    }
}
