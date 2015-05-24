namespace Org.Cen.Devices.Pid.Com
{

    using Cen.Com.Out;
    using Communication.Out;
    using Org.Cen.Devices.Pid.Com;


    ////@formatter:off
    //@DeviceDataSignature(deviceName = INavigationDevice.NAME, methods = { 
    //        @DeviceMethodSignature(
    //        header = WriteMotionEndDetectionParameterOutData.HEADER, 
    //        methodName="writeMotionEndDetection",
    //        type = DeviceMethodType.INPUT,
    //        parameters = {}) 
    //        })
    ////@formatter:on
    public class MotionEndDetectionParametersReadOutData : OutData
    {

        private const string HEADER = "~";

        /**
         * Constructor.
         */
        public MotionEndDetectionParametersReadOutData()
            : base()
        {

        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}