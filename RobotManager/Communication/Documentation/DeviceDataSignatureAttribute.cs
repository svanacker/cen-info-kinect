namespace Org.Cen.Com.In
{

    public class DeviceDataSignatureAttribute : System.Attribute {

        /**
         * The name of the device.
         */
        string DeviceName { get; set; }

        /**
         * The method to do something on devices.
         */
        DeviceMethodSignatureAttribute[] Methods { get; set; }
    }
}
