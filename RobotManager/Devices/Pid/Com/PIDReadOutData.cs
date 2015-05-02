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

        private const string HEADER = "q";

        protected int index;

        public int getIndex()
        {
            return index;
        }

        public void setIndex(int index)
        {
            this.index = index;
        }

        /**
         * Constructor.
         */
        public PIDReadOutData(int index)
            : base()
        {
            this.index = index;
        }

        public override string getArguments()
        {
            string result = ComDataUtils.format(index, 2);
            return result;
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }


}
