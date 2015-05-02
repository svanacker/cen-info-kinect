namespace Org.Cen.Devices.Pid.Com
{
    using NUnit.Framework;

    public class ReadMotionParameterInDataDecoderTest
    {
        [Test]
        public void ShouldDecodeReadParameterData()
        {
            string data = "apm00-01-E0-A8-0081-0082-0103-002ACA-002ACB-1-0-0";

            MotionParameterReadInDataDecoder decoder = new MotionParameterReadInDataDecoder();
            MotionParameterReadInData inData = (MotionParameterReadInData)decoder.Decode(data);

            MotionParameterData motionParameterData = inData.MotionParameterData;
            Assert.AreEqual(1, motionParameterData.Acceleration);
            Assert.AreEqual(224, motionParameterData.Speed);
            Assert.AreEqual(168, motionParameterData.SpeedMax);
            Assert.AreEqual(129, motionParameterData.Time1);
            Assert.AreEqual(130, motionParameterData.Time2);
            Assert.AreEqual(259, motionParameterData.Time3);
            Assert.AreEqual(10954, motionParameterData.Position1);
            Assert.AreEqual(10955, motionParameterData.Position2);
            // TODO : 3 more informations

            int length = decoder.GetDataLength(MotionParameterReadInData.HEADER);
            Assert.AreEqual(length, data.Length);
        }
    }
}
