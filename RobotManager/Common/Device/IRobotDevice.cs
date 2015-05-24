namespace Org.Cen.Common.Device
{
    using System.Collections.Generic;
    using Request;

    ///
    /// Encapsulate a device for a Robot (Ex : Servo, Arm, Motor Controller).
    /// 
    public interface IRobotDevice
    {
        string Header { get; }

        /// <summary>
        /// Name of the device.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// If the device is enabled or not.
        /// </summary>
        /// <returns></returns>
        bool Enabled { get; set; }

        ///
        /// Unstructured device information
        /// 
        IDictionary<string, object> GetProperties();

        /// 
        /// <summary>Return a specific property by a name</summary>
        ///  @param name property name.
        /// 
        object GetProperty(string name);

        ///
        /// Set a property value by its name
        /// @param propertyName the name of the property
        /// @param value the value.
        ///
        void SetProperty(string propertyName, object value);

        ///
        /// Initialization of the device.
        /// 
        void Initialize(IRobotServiceProvider servicesProvider);

        ///
        /// Handle a request for that Device.
        /// 
        void HandleRequest(IRobotDeviceRequest request);
    }
}
