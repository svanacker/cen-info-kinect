namespace Org.Cen.Devices.Pid.Com
{
    using Motion.Pid.Com;
    using NUnit.Framework;

    public class ReadMotionParameterInDataDecoderTest
    {
        [Test]
        public void ShouldDecodeReadParameterData()
        {
            string data = "apm00-01-E0-A8-0081-0082-0103-002ACA-002ACB-002ACC-1-0-0";

            MotionParameterReadInDataDecoder decoder = new MotionParameterReadInDataDecoder();
            MotionParameterReadInData inData = (MotionParameterReadInData)decoder.Decode(data);

            MotionParameterData motionParameterData = inData.MotionParameterData;
            Assert.AreEqual(0X01, motionParameterData.Acceleration);
            Assert.AreEqual(0xE0, motionParameterData.Speed);
            Assert.AreEqual(0xA8, motionParameterData.SpeedMax);
            Assert.AreEqual(0x0081, motionParameterData.Time1);
            Assert.AreEqual(0x0082, motionParameterData.Time2);
            Assert.AreEqual(0x0103, motionParameterData.Time3);
            Assert.AreEqual(0x2ACA, motionParameterData.Position1);
            Assert.AreEqual(0x2ACB, motionParameterData.Position2);
            Assert.AreEqual(0x2ACC, motionParameterData.NextPosition);
            // TODO : 3 more informations

            int length = decoder.GetDataLength(MotionParameterReadInData.HEADER);
            Assert.AreEqual(length, data.Length);
        }
    }
}
