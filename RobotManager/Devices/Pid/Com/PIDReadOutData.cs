namespace Org.Cen.Devices.Pid.Com
{
    using Cen.Com.Out;
    using Cen.Com.Utils;

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

        public override string getArguments()
        {
            string result = ComDataUtils.format(Index, 2);
            return result;
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}
