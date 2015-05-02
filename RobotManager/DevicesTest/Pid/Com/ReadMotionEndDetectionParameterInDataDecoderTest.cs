namespace Org.Cen.Devices.Pid.Com
{
    using NUnit.Framework;
    using Org.Cen.Devices.Pid;

    public class ReadMotionEndDetectionParameterInDataDecoderTest
    {
        [Test]
        public void ShouldDecodeReadMotionEndDetectionParameterData()
        {
            string data = "apP01-03-0A-0B-3C";

            MotionEndDetectionParameterReadInDataDecoder decoder = new MotionEndDetectionParameterReadInDataDecoder();
            MotionEndDetectionParameterReadInData inData = (MotionEndDetectionParameterReadInData)decoder.Decode(data);
            MotionEndDetectionParameter motionEndDetectionParameter = inData.EndDetectionParameter;

            Assert.AreEqual(1.0f, motionEndDetectionParameter.AbsDeltaPositionIntegralFactorThreshold);
            Assert.AreEqual(3.0f, motionEndDetectionParameter.MaxUIntegralFactorThreshold);
            Assert.AreEqual(10.0f, motionEndDetectionParameter.MaxUIntegralConstantThreshold);
            Assert.AreEqual(11.0f, motionEndDetectionParameter.TimeRangeAnalysis);
            Assert.AreEqual(60.0f, motionEndDetectionParameter.NoAnalysisAtStartupTime);

            int length = decoder.GetDataLength(MotionEndDetectionParameterReadInData.HEADER);
            Assert.AreEqual(length, data.Length);
        }
    }
}
