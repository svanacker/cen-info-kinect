using Devices.Pid;
using Org.Cen.Com.Out;
using Org.Cen.Com.Utils;

namespace Org.Cen.Devices.Pid.Com { 

/**
 * The encapsulation of the data which must be sent to change the PID.
 */
////@formatter:off
//[DeviceDataSignature(deviceName = INavigationDevice.NAME, methods = { @DeviceMethodSignature(
//        header = WritePIDOutData.HEADER,
//        methodName = "writePID",
//        type = DeviceMethodType.INPUT,
//        parameters = { @DeviceParameter(name = "index", length = 2, type = DeviceParameterType.UNSIGNED, unit = ""),
//                @DeviceParameter(name = "p", length = 2, type = DeviceParameterType.UNSIGNED, unit = ""),
//                @DeviceParameter(name = "i", length = 2, type = DeviceParameterType.UNSIGNED, unit = ""),
//                @DeviceParameter(name = "d", length = 2, type = DeviceParameterType.UNSIGNED, unit = ""),
//                @DeviceParameter(name = "maxI", length = 2, type = DeviceParameterType.UNSIGNED, unit = "") }) })
////@formatter:on
public class WritePIDOutData : OutData {

    /** The Header which is used by the message to change the PID. */
    public const string HEADER = "p";

    /** Change all PID index in one Time. */
    protected const int ALL_PID_INDEX = -1;

    protected PIDData data;

    private int index;

    /**
     * Constructor
     * 
     * @param index
     *            the index of the PID
     * 
     * @param thetaData
     *            the data of the PID
     */
    public WritePIDOutData(int index, PIDData data) : base() {
        this.index = index;
        this.data = data;
    }

    public override string getArguments() {
        return PIDEngineToData(data);
    }

    public override string getHeader() {
        return HEADER;
    }

    /**
     * Transform the PIDEngine data to a string with hexadecimal Value
     * 
     * @param engineData
     *            the data which must be converted
     * @return
     */
    protected string PIDEngineToData(PIDData engineData) {
        string indexString = ComDataUtils.format(index, 2);
        string pString = ComDataUtils.format(engineData.P, 2);
        string iString = ComDataUtils.format(engineData.I, 2);
        string dString = ComDataUtils.format(engineData.D, 2);
        string maxIString = ComDataUtils.format(engineData.MaxI, 2);

        return indexString + pString + iString + dString + maxIString;
    }
}
}