namespace Org.Cen.Devices.Pid.Com
{
    using Cen.Com.Out;
    using Communication.Out;
    using Communication.Utils;
    using global::System.Text;


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
    public class MotionEndDetectionParameterWriteOutData : OutData
    {
        private const string HEADER = "pp";

        public MotionEndDetectionParameter Parameter { get; private set; }

        /**
         * Constructor.
         */
        public MotionEndDetectionParameterWriteOutData(MotionEndDetectionParameter endDetectionParameter)
        {
            this.Parameter = endDetectionParameter;
        }

        public override string GetArguments()
        {
            StringBuilder result = new StringBuilder();
            result.Append(DataParserUtils
                    .format((int)Parameter.AbsDeltaPositionIntegralFactorThreshold, 2));
            result.Append("-");
            result.Append(DataParserUtils.format((int)Parameter.MaxUIntegralFactorThreshold, 2));
            result.Append("-");
            result.Append(DataParserUtils.format((int)Parameter.MaxUIntegralConstantThreshold, 2));
            result.Append("-");
            result.Append(DataParserUtils.format(Parameter.TimeRangeAnalysis, 2));
            result.Append("-");
            result.Append(DataParserUtils.format(Parameter.NoAnalysisAtStartupTime, 2));

            return result.ToString();
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}