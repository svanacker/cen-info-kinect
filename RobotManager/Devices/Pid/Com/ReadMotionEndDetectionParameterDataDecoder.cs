namespace Org.Cen.Devices.Pid.Com
{
    using global::System.Collections.Generic;
    using global::System.Globalization;
    using Org.Cen.Com;
    using Org.Cen.Com.In;

    public class ReadMotionEndDetectionParameterDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { ReadMotionEndDetectionParameterInData.HEADER };
        }

        public InData Decode(string data)
        {
            MotionEndDetectionParameter parameter = new MotionEndDetectionParameter();


            // apP01-03-0A-0A-3C
            // AbsDeltaPositionIntegralFactorThreshold 
            string absDeltaPositionIntegralFactorThresholdAsString = data.Substring(3, 2);
            parameter.AbsDeltaPositionIntegralFactorThreshold = (float) int.Parse(absDeltaPositionIntegralFactorThresholdAsString, NumberStyles.HexNumber);

            // MaxUIntegralFactorThreshold
            string maxUIntegralFactorThresholdAsString = data.Substring(6, 2);
            parameter.MaxUIntegralFactorThreshold = (float)int.Parse(maxUIntegralFactorThresholdAsString, NumberStyles.HexNumber);

            // MaxUIntegralConstantThreshold
            string maxUIntegralConstantThresholdAsString = data.Substring(9, 2);
            parameter.MaxUIntegralConstantThreshold = (float)int.Parse(maxUIntegralConstantThresholdAsString, NumberStyles.HexNumber);

            // TimeRangeAnalysis
            string timeRangeAnalysisAsString = data.Substring(12, 2);
            parameter.TimeRangeAnalysis = int.Parse(timeRangeAnalysisAsString, NumberStyles.HexNumber);

            // TimeRangeAnalysis
            string noAnalysisAtStartupTimeAsString = data.Substring(15, 2);
            parameter.NoAnalysisAtStartupTime = int.Parse(noAnalysisAtStartupTimeAsString, NumberStyles.HexNumber);

            ReadMotionEndDetectionParameterInData result = new ReadMotionEndDetectionParameterInData(parameter);
            return result;
        }

        public int GetDataLength(string header)
        {
            return 17;
        }
    }
}
