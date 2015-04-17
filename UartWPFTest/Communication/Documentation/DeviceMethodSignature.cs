namespace Org.Cen.Com.In
{

/**
 * Describe a remote method called with its name, and all of its parameter.
 */
public class DeviceMethodSignatureAttribute {

    /**
     * The header as first characters to determine which devices is concerned by
     * the call.
     * 
     * @return
     */
    string Header { get; set; }

    /**
     * The name of the method which is called (hint very useful)
     * 
     * @return
     */
    string MethodName { get; set; }

    /**
     * If data comes from the main board or is sent by the main Board.
     * 
     * @return
     */
    DeviceMethodType MethodType { get; set; }

    /**
     * Parameters array for the device method.
     * 
     * @return
     */
    DeviceParameterAttribute[] Parameters { get; set; }
}
}