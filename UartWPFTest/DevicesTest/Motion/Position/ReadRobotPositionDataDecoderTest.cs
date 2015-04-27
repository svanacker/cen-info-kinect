using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesTest.Motion.Position
{
    using NUnit.Framework;
    using Org.Cen.Devices.Pid.Com;
    using Org.Com.Devices.Motion.Position;
    using Org.Com.Devices.Motion.Position.Com;

    public class ReadRobotPositionDataDecoderTest
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
