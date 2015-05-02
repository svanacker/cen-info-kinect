namespace Org.Cen.Devices.Motion.Position.Com
{
    using NUnit.Framework;
    using Org.Com.Devices.Motion.Position;

    public class ReadRobotPositionInDataDecoderTest
    {
        [Test]
        public void ShouldDecodeReadRobotPositionDataDecoder()
        {
            string data = "anr0100-0200-0300";

            ReadRobotPositionDataDecoder decoder = new ReadRobotPositionDataDecoder();
            ReadRobotPositionInData inData = (ReadRobotPositionInData)decoder.Decode(data);

            RobotPosition robotPosition = inData.Position;
            int x = robotPosition.X;
            int y = robotPosition.Y;
            int deciDegreeAngle = robotPosition.DeciDegreeAngle;

            Assert.AreEqual(256, x);
            Assert.AreEqual(512, y);
            Assert.AreEqual(768, deciDegreeAngle);

            Assert.AreEqual(data.Length, decoder.GetDataLength(ReadRobotPositionInData.HEADER));
        }
    }
}
