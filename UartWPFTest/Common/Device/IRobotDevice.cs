namespace Org.Cen.Common.Device
{
    using System.Collections;
    using System.Collections.Generic;
    using Request;

    /**
     * Encapsulate a device for a Robot (Ex : Servo, Arm, Motor Controller).
     */

    public interface IRobotDevice
    {

        /**
     * The name of the device.
     * 
     * @return
     */
        string getName();

        /**
     * Unstructured device information
     * 
     * @return
     */
        IDictionary<string, object> getProperties();

        /**
     * Return a specific property by a name.
     * 
     * @param name
     *            property name.
     * @return
     */
        object getProperty(string name);

        /**
     * Set a property value by its name
     * 
     * @param propertyName
     *            the name of the property
     * @param value
     *            the value.
     */
        void setProperty(string propertyName, object value);

        /**
     * Initialization of the device.
     * 
     * @param servicesProvider
     */
        void initialize(IRobotServiceProvider servicesProvider);

        /**
     * Handle a request for that Device.
     * 
     * @param request
     */
        void handleRequest(IRobotDeviceRequest request);

        /**
     * Is the device enabled or not.
     * 
     * @return
     */
        bool isEnabled();

        void setEnabled(bool enabled);

    }
}
