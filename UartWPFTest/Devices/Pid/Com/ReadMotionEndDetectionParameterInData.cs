namespace Org.Cen.Devices.Com
{
    using Cen.Com.In;
    using Pid.Com;

    public class ReadMotionEndDetectionParameterInData : InData {

    public const string HEADER = "~";

    private MotionEndDetectionParameter data;

    public ReadMotionEndDetectionParameterInData(MotionEndDetectionParameter data): base() {
        this.data = data;
    }

    public MotionEndDetectionParameter getData() {
        return data;
    }

    public override string ToString()
    {
        return typeof(ReadMotionEndDetectionParameterInData).Name + "{data=" + data + "}";
    }
}
}