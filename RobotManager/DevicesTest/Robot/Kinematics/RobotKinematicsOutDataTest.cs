namespace Org.Cen.Devices.Robot.Kinematics
{
    using NUnit.Framework;

    public class RobotKinematicsOutDataTest
    {
        [Test]
        public void Should_RobotKinematicsLoadDefaultValuesOutData_Be_Ok()
        {
            RobotKinematicsLoadDefaultValuesOutData outData = new RobotKinematicsLoadDefaultValuesOutData();
            string message = outData.GetMessage();
            Assert.AreEqual("Kd", message);
        }

        // PulseByRotation

        [Test]
        public void Should_RobotKinematicsPulseByRotationReadOutData_Be_Ok()
        {
            RobotKinematicsPulseByRotationReadOutData outData = new RobotKinematicsPulseByRotationReadOutData();
            string message = outData.GetMessage();
            Assert.AreEqual("Kp", message);
        }

        [Test]
        public void Should_RobotKinematicsPulseByRotationWriteOutData_Be_Ok()
        {
            RobotKinematicsPulseByRotationWriteOutData outData = new RobotKinematicsPulseByRotationWriteOutData(0x1234);
            string message = outData.GetMessage();
            Assert.AreEqual("KP1234", message);
        }

        // RotationBySecondAtFullSpeed

        [Test]
        public void Should_RobotKinematicsRotationBySecondAtFullSpeedReadOutData_Be_Ok()
        {
            RobotKinematicsRotationBySecondAtFullSpeedReadOutData outData = new RobotKinematicsRotationBySecondAtFullSpeedReadOutData();
            string message = outData.GetMessage();
            Assert.AreEqual("Kr", message);
        }

        [Test]
        public void Should_RobotKinematicsRotationBySecondAtFullSpeedWriteOutData_Be_Ok()
        {
            RobotKinematicsRotationBySecondAtFullSpeedWriteOutData outData = new RobotKinematicsRotationBySecondAtFullSpeedWriteOutData(0x12);
            string message = outData.GetMessage();
            Assert.AreEqual("KR12", message);
        }

        // WheelsAverageForOnePulseLength

        [Test]
        public void Should_RobotKinematicsWheelsAverageForOnePulseLengthReadOutData_Be_Ok()
        {
            RobotKinematicsWheelsAverageForOnePulseLengthReadOutData outData = new RobotKinematicsWheelsAverageForOnePulseLengthReadOutData();
            string message = outData.GetMessage();
            Assert.AreEqual("Kl", message);
        }

        [Test]
        public void Should_RobotKinematicsWheelsAverageForOnePulseLengthWriteOutData_Be_Ok()
        {
            RobotKinematicsWheelsAverageForOnePulseLengthWriteOutData outData = new RobotKinematicsWheelsAverageForOnePulseLengthWriteOutData(0x123456);
            string message = outData.GetMessage();
            Assert.AreEqual("KL123456", message);
        }

        // WheelDeltaForOnePulseLength

        [Test]
        public void Should_RobotKinematicsWheelDeltaForOnePulseLengthReadOutData_Be_Ok()
        {
            RobotKinematicsWheelDeltaForOnePulseLengthReadOutData outData = new RobotKinematicsWheelDeltaForOnePulseLengthReadOutData();
            string message = outData.GetMessage();
            Assert.AreEqual("Kw", message);
        }

        [Test]
        public void Should_RobotKinematicsWheelDeltaForOnePulseLengthWriteOutData_Be_Ok()
        {
            RobotKinematicsWheelDeltaForOnePulseLengthWriteOutData outData = new RobotKinematicsWheelDeltaForOnePulseLengthWriteOutData(0x123456);
            string message = outData.GetMessage();
            Assert.AreEqual("KW123456", message);
        }

        // WheelsDistance

        [Test]
        public void Should_RobotKinematicsWheelsDistanceReadOutData_Be_Ok()
        {
            RobotKinematicsWheelsDistanceReadOutData outData = new RobotKinematicsWheelsDistanceReadOutData();
            string message = outData.GetMessage();
            Assert.AreEqual("Kh", message);
        }

        [Test]
        public void Should_RobotKinematicsWheelsDistanceWriteOutData_Be_Ok()
        {
            RobotKinematicsWheelsDistanceWriteOutData outData = new RobotKinematicsWheelsDistanceWriteOutData(0x123456);
            string message = outData.GetMessage();
            Assert.AreEqual("KH123456", message);
        }
    }
}
