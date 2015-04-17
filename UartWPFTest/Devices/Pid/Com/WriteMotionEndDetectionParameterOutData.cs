namespace Org.Cen.Devices.Pid.Com
{
    using Cen.Com.Out;
    using Cen.Com.Utils;


    //@formatter:off
    //@DeviceDataSignature(deviceName = INavigationDevice.NAME, methods = { 
    //        @DeviceMethodSignature(
    //                header = WriteMotionEndDetectionParameterOutData.HEADER,
    //                methodName="writeMotionEndDetection",
    //                type = DeviceMethodType.INPUT, parameters = {
    //                @DeviceParameter(name = "absDeltaPositionIntegralFactorThreshold", length = 2,
    //                        type = DeviceParameterType.UNSIGNED, unit = ""),
    //                @DeviceParameter(name = "maxUIntegralFactorThreshold", length = 2, type = DeviceParameterType.UNSIGNED,
    //                        unit = ""),
    //                @DeviceParameter(name = "maxUIntegralConstantThreshold", length = 2,
    //                        type = DeviceParameterType.UNSIGNED, unit = ""),
    //                @DeviceParameter(name = "timeRangeAnalysis", length = 2, type = DeviceParameterType.UNSIGNED,
    //                        unit = " pidTime"),
    //                @DeviceParameter(name = "noAnalysisAtStartupTime", length = 2, type = DeviceParameterType.UNSIGNED,
    //                        unit = "pidTime") }) })
    ////@formatter:on
    public class WriteMotionEndDetectionParameterOutData : OutData
    {

        private const string HEADER = "=";

        public MotionEndDetectionParameter getEndDetectionParameter()
        {
            return endDetectionParameter;
        }

        private MotionEndDetectionParameter endDetectionParameter;

        /**
         * Constructor.
         */
        public WriteMotionEndDetectionParameterOutData(MotionEndDetectionParameter endDetectionParameter)
        {
            this.endDetectionParameter = endDetectionParameter;
        }

        public override string getArguments()
        {
            string result = ComDataUtils
                    .format((int)endDetectionParameter.getAbsDeltaPositionIntegralFactorThreshold(), 2);
            result += ComDataUtils.format((int)endDetectionParameter.getMaxUIntegralFactorThreshold(), 2);
            result += ComDataUtils.format((int)endDetectionParameter.getMaxUIntegralConstantThreshold(), 2);
            result += ComDataUtils.format(endDetectionParameter.getTimeRangeAnalysis(), 2);
            result += ComDataUtils.format(endDetectionParameter.getNoAnalysisAtStartupTime(), 2);
            return result;
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}