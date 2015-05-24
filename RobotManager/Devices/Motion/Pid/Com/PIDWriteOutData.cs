namespace Org.Cen.Devices.Pid.Com
{
    using Communication.Out;
    using Communication.Utils;
    using Devices.Pid;
    using Org.Cen.Com.Out;

    /**
     * The encapsulation of the data which must be sent to change the PID.
     */
    ////@formatter:off
    //[DeviceDataSignature(deviceName = INavigationDevice.NAME, methods = { @DeviceMethodSignature(
    //        header = WritePIDOutData.HEADER,
    //        methodName = "writePID",
    //        type = DeviceMethodType.INPUT,
    //        parameters = { @DeviceParameter(name = "index", length = 2, type = DeviceParameterType.UNSIGNED, unit = ""),
    //                @DeviceParameter(name = "p", length = 2, type = DeviceParameterType.UNSIGNED, unit = ""),
    //                @DeviceParameter(name = "i", length = 2, type = DeviceParameterType.UNSIGNED, unit = ""),
    //                @DeviceParameter(name = "d", length = 2, type = DeviceParameterType.UNSIGNED, unit = ""),
    //                @DeviceParameter(name = "maxI", length = 2, type = DeviceParameterType.UNSIGNED, unit = "") }) })
    ////@formatter:on
    public class PIDWriteOutData : OutData
    {

        /** The Header which is used by the message to change the PID. */
        public const string HEADER = "pw";

        /** Change all PID index in one Time. */
        protected const int ALL_PID_INDEX = -1;

        public int Index { get; private set; }

        public PidData Data { get; private set; }

        public PIDWriteOutData(int index, PidData data)
            : base()
        {
            this.Index = index;
            this.Data = data;
        }

        public override string GetArguments()
        {
            return PidEngineToData(Data);
        }

        public override string GetHeader()
        {
            return HEADER;
        }

        protected string PidEngineToData(PidData engineData)
        {
            string indexString = DataParserUtils.format(Index, 2);
            string pString = DataParserUtils.format(engineData.P, 2);
            string iString = DataParserUtils.format(engineData.I, 2);
            string dString = DataParserUtils.format(engineData.D, 2);
            string maxIString = DataParserUtils.format(engineData.MaxI, 2);

            return indexString + "-" + pString + "-" + iString + "-" + dString + "-" + maxIString;
        }
    }
}