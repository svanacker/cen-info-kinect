namespace Org.Cen.Devices.Pid.Com
{
    using Cen.Com.Out;
    using Communication.Out;
    using Communication.Utils;

    /**
     * Encapsulation of the message which ask for PID.
     */
    //[DeviceDataSignature(deviceName = INavigationDevice.NAME, methods = { 
    //        @DeviceMethodSignature(
    //                header = ReadPIDOutData.HEADER,
    //                methodName = "readPID",
    //                type = DeviceMethodType.INPUT,
    //                parameters = {
    //                        @DeviceParameter(name = "index", length = 2, type = DeviceParameterType.SIGNED, unit = "")
    //                })
    //        })
    public class PIDReadOutData : OutData
    {
        private const string HEADER = "pr";

        public int Index { get; private set; }

        /**
         * Constructor.
         */
        public PIDReadOutData(int index)
            : base()
        {
            this.Index = index;
        }

        public override string GetArguments()
        {
            string result = DataParserUtils.format(Index, 2);
            return result;
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
