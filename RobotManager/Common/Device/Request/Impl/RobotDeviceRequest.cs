namespace Org.Cen.Common.Device.Request.Impl
{
    using System.Runtime.CompilerServices;


/**
 * Object representing a request to send to a device of the robot.
 * 
 * @author Emmanuel ZURMELY
 */
public abstract class RobotDeviceRequest : IRobotDeviceRequest {

    private static int counter = 0;

    [MethodImpl(MethodImplOptions.Synchronized)]
    private static long getNextUID() {
        return counter++;
    }

    protected string deviceName;

    protected int priority;

    protected long timeStamp;

    protected long uid;

    /**
     * Constructor.
     */
    public RobotDeviceRequest(string deviceName) : base() {
        this.deviceName = deviceName;
        uid = getNextUID();
        priority = 0;
        // TODO timeStamp = System.currentTimeMillis();
    }

    /**
     * Returns the device name.
     * 
     * @return the device name
     */
    public string GetDeviceName() {
        return deviceName;
    }

    /**
     * Returns the priority of the request.
     * 
     * @return the priority of the request
     */
    public int GetPriority() {
        return priority;
    }

    /**
     * Returns the time-stamp of this request.
     * 
     * @return the time-stamp of this request
     */
    public long GetTimeStamp() {
        return timeStamp;
    }

    public long GetUID() {
        return uid;
    }
}
}