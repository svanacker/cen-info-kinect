namespace Org.Cen.Devices.Motion.Position.Com
{
    using NUnit.Framework;
    using Org.Cen.Devices.Motion.Position;

    public class WheelPositionDataInDecoderTest
    {
        [Test]
        public void ShouldDecodeReadWheelPositionDataDecoder()
        {
            string data = "awrFFFE7960-00004E20";

            WheelPositionReadInDataDecoder decoder = new WheelPositionReadInDataDecoder();
            WheelPositionReadInData inData = (WheelPositionReadInData)decoder.Decode(data);
            WheelPositionData wheelPositionData = inData.WheelPosition;
            long leftPosition = wheelPositionData.LeftPosition;
            long rightPosition = wheelPositionData.RightPosition;

            Assert.AreEqual(-100000, leftPosition);
            Assert.AreEqual(20000, rightPosition);

            Assert.AreEqual(data.Length, decoder.GetDataLength(WheelPositionReadInData.HEADER));
        }
    }
}
