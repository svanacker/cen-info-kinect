

namespace Org.Cen.Devices.Pid.Com {
    using Cen.Com.Out;
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
public class ReadMotionEndDetectionParametersOutData : OutData {

    private const string HEADER = "~";

    /**
     * Constructor.
     */
    public ReadMotionEndDetectionParametersOutData() : base() {
        
    }

    public override string getHeader() {
        return HEADER;
    }
}}