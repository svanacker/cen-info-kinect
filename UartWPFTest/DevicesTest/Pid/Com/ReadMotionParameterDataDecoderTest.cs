namespace DevicesTest.Pid.Com
{
    using Devices.Pid.Com;
    using NUnit.Framework;

    public class ReadMotionParameterDataDecoderTest
    {
        [Test]
        public void ShouldDecodeReadParameterData()
        {
            string data = "apm00-01-E0-A8-0081-0081-0103-002ACA-002ACA-1-0-0M";

            ReadMotionParameterDataDecoder decoder = new ReadMotionParameterDataDecoder();
            ReadMotionParameterInData inData = (ReadMotionParameterInData)decoder.Decode(data);

            MotionParameterData motionParameterData = inData.MotionParameterData;
            Assert.AreEqual(1, motionParameterData.Acceleration);
            Assert.AreEqual(224, motionParameterData.Speed);
            Assert.AreEqual(168, motionParameterData.SpeedMax);
            Assert.AreEqual(129, motionParameterData.Time1);
            Assert.AreEqual(129, motionParameterData.Time2);
            Assert.AreEqual(259, motionParameterData.Time3);
            Assert.AreEqual(10954, motionParameterData.Position1);
            Assert.AreEqual(10954, motionParameterData.Position2);
            // TODO : 3 more informations

            int length = decoder.GetDataLength(ReadMotionParameterInData.HEADER);
            Assert.AreEqual(length, data.Length);
        }
    }
}
