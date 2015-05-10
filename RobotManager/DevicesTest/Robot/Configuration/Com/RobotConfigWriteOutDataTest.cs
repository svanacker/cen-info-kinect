namespace Org.Cen.Devices.Robot.Configuration.Com
{
    using NUnit.Framework;
    using Robot;
    using Start.Com;

    public class RobotConfigWriteOutDataTest
    {
        [Test]
        public void ShouldGenerateMatchWritePositionOutData()
        {
            string expected = "cw1234";

            RobotConfig robotConfig = new RobotConfig(0x1234);
            RobotConfigWriteOutData outData = new RobotConfigWriteOutData(robotConfig);

            string actual = outData.getMessage();

            Assert.AreEqual(expected, actual);
        }
    }
}
