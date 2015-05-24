namespace Org.Cen.Devices.Robot.Kinematics
{
    using Configuration.Com;
    using NUnit.Framework;

    public class RobotKinematicsInDataDecoderTest
    {
        [Test]
        public void Should_Decode_RobotKinematicsPulseByRotationReadInData()
        {
            string data = "aKr1234";

            RobotKinematicsPulseByRotationReadInDataDecoder decoder = new RobotKinematicsPulseByRotationReadInDataDecoder();
            RobotKinematicsPulseByRotationReadInData inData = (RobotKinematicsPulseByRotationReadInData)decoder.Decode(data);

            Assert.AreEqual(0x1234, inData.Value);

            int length = decoder.GetDataLength(null);
            Assert.AreEqual(length, data.Length);
        }

        [Test]
        public void Should_Decode_RobotKinematicsRotationBySecondAtFullSpeedReadInData()
        {
            string data = "aKp12";

            RobotKinematicsRotationBySecondAtFullSpeedReadInDataDecoder decoder = new RobotKinematicsRotationBySecondAtFullSpeedReadInDataDecoder();
            RobotKinematicsRotationBySecondAtFullSpeedReadInData inData = (RobotKinematicsRotationBySecondAtFullSpeedReadInData)decoder.Decode(data);

            Assert.AreEqual(0x12, inData.Value);

            int length = decoder.GetDataLength(null);
            Assert.AreEqual(length, data.Length);
        }

        [Test]
        public void Should_Decode_RobotKinematicsWheelDeltaForOnePulseLengthReadInData()
        {
            string data = "aKw123456";

            RobotKinematicsWheelDeltaForOnePulseLengthReadInDataDecoder decoder = new RobotKinematicsWheelDeltaForOnePulseLengthReadInDataDecoder();
            RobotKinematicsWheelDeltaForOnePulseLengthReadInData inData = (RobotKinematicsWheelDeltaForOnePulseLengthReadInData)decoder.Decode(data);

            Assert.AreEqual(0x123456, inData.Value);

            int length = decoder.GetDataLength(null);
            Assert.AreEqual(length, data.Length);
        }

        [Test]
        public void Should_Decode_RobotKinematicsWheelsAverageForOnePulseLengthReadInData()
        {
            string data = "aKl123456";

            RobotKinematicsWheelsAverageForOnePulseLengthReadInDataDecoder decoder = new RobotKinematicsWheelsAverageForOnePulseLengthReadInDataDecoder();
            RobotKinematicsWheelsAverageForOnePulseLengthReadInData inData = (RobotKinematicsWheelsAverageForOnePulseLengthReadInData)decoder.Decode(data);

            Assert.AreEqual(0x123456, inData.Value);

            int length = decoder.GetDataLength(null);
            Assert.AreEqual(length, data.Length);
        }

        [Test]
        public void Should_Decode_RobotKinematicsWheelsDistanceReadInData()
        {
            string data = "aKh123456";

            RobotKinematicsWheelsDistanceReadInDataDecoder decoder = new RobotKinematicsWheelsDistanceReadInDataDecoder();
            RobotKinematicsWheelsDistanceReadInData inData = (RobotKinematicsWheelsDistanceReadInData)decoder.Decode(data);

            Assert.AreEqual(0x123456, inData.Value);

            int length = decoder.GetDataLength(null);
            Assert.AreEqual(length, data.Length);
        }

    }
}
