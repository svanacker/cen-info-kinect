namespace Org.Cen.Devices.Robot.Configuration.Com
{
    using NUnit.Framework;

    public class RobotConfigReadInDataDecoderTest
    {
        [Test]
        public void ShouldDecodeRobotConfigReadInData()
        {
            string data = "acr1234";

            RobotConfigReadInDataDecoder decoder = new RobotConfigReadInDataDecoder();
            RobotConfigReadInData inData = (RobotConfigReadInData)decoder.Decode(data);

            RobotConfig robotConfig = inData.Config;

            Assert.AreEqual(0x1234, robotConfig.Value);

            int length = decoder.GetDataLength(RobotConfigReadInData.HEADER);
            Assert.AreEqual(length, data.Length);
        }
    }
}
