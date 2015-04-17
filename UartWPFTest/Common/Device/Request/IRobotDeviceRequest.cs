namespace Org.Cen.Common.Device.Request
{

    /**
     * Representing a request to send to a device of the robot.
     * 
     * @author Emmanuel ZURMELY
     */
    public interface IRobotDeviceRequest
    {

        /**
         * Returns the device name.
         * 
         * @return the device name
         */
        string GetDeviceName();

        /**
         * Returns the priority of the request.
         * 
         * @return the priority of the request
         */
        int GetPriority();

        /**
         * Returns the time-stamp of this request.
         * 
         * @return the time-stamp of this request
         */
        long GetTimeStamp();

        /**
         * Uid to differentiate the device requests.
         * 
         * @return
         */
        long GetUID();
    }


}
