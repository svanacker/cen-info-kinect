namespace Devices.Pid.Com
{
    using Org.Cen.Com.In;

    public class ReadMotionParameterInData : InData
    {
        public const string HEADER = "pm";

        public MotionParameterData MotionParameterData { get; private set; }

        public ReadMotionParameterInData(MotionParameterData motionParameterData)
            : base()
        {
            this.MotionParameterData = motionParameterData;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{data=" + MotionParameterData + "}";
        }
    }
}
