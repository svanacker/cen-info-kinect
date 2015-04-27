using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesTest.Motion.Position
{
    using Devices.Motion.Position;
    using Devices.Motion.Position.Com;
    using NUnit.Framework;
    using Org.Cen.Com.In;
    using Org.Cen.Devices.Pid.Com;

    public class WheelPositionDataDecoderTest
    {
        [Test]
        public void ShouldDecodeReadWheelPositionDataDecoder()
        {
            string data = "awr0FE7960-004E20";

            WheelPositionDataDecoder decoder = new WheelPositionDataDecoder();
            ReadWheelPositionInData inData = (ReadWheelPositionInData) decoder.Decode(data);
            WheelPositionData wheelPositionData = inData.WheelPosition;
            int leftPosition = wheelPositionData.LeftPosition;
            int rightPosition = wheelPositionData.RightPosition;

            Assert.AreEqual(-100000, leftPosition);
            Assert.AreEqual(20000, rightPosition);

            Assert.AreEqual(data.Length, decoder.GetDataLength(ReadWheelPositionInData.HEADER));
        }
    }
}
