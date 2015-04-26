namespace DevicesTest.Pid.Com
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Devices.Pid;
    using Devices.Pid.Com;
    using NUnit.Framework;
    using Org.Cen.Devices.Com;
    using Org.Cen.Devices.Pid.Com;

    public class ReadMotionEndDetectionParameterDataDecoderTest
    {
        [Test]
        public void ShouldDecodeReadMotionEndDetectionParameterDataDecoder()
        {
            string data = "apP01-03-0A-0B-3C";

            ReadMotionEndDetectionParameterDataDecoder decoder = new ReadMotionEndDetectionParameterDataDecoder();
            ReadMotionEndDetectionParameterInData inData = (ReadMotionEndDetectionParameterInData)decoder.Decode(data);
            MotionEndDetectionParameter motionEndDetectionParameter = inData.EndDetectionParameter;

            Assert.AreEqual(1.0f, motionEndDetectionParameter.AbsDeltaPositionIntegralFactorThreshold);
            Assert.AreEqual(3.0f, motionEndDetectionParameter.MaxUIntegralFactorThreshold);
            Assert.AreEqual(10.0f, motionEndDetectionParameter.MaxUIntegralConstantThreshold);
            Assert.AreEqual(11.0f, motionEndDetectionParameter.TimeRangeAnalysis);
            Assert.AreEqual(60.0f, motionEndDetectionParameter.NoAnalysisAtStartupTime);

            int length = decoder.GetDataLength(ReadMotionEndDetectionParameterInData.HEADER);
            Assert.AreEqual(length, data.Length);
        }
    }
}
