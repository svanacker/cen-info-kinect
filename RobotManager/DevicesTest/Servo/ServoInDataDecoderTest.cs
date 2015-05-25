namespace Org.Cen.Devices.Servo
{
    using Com;
    using NUnit.Framework;

    public class ServoInDataDecoderTest
    {
        [Test]
        public void Should_Decode_ServoReadParametersInData()
        {
            string data = "asr01-23-4567-8901";

            ServoReadParametersInDataDecoder decoder = new ServoReadParametersInDataDecoder();
            ServoReadParametersInData inData = (ServoReadParametersInData) decoder.Decode(data);

            ServoData servoData = inData.Data;

            Assert.AreEqual(0x01, servoData.ServoIndex);
            Assert.AreEqual(0x23, servoData.ServoSpeed);
            Assert.AreEqual(0x4567, servoData.ServoCurrentPosition);
            Assert.AreEqual(0x8901, servoData.ServoTargetPosition);

            int length = decoder.GetDataLength(null);
            Assert.AreEqual(length, data.Length);
        }
    }
}
