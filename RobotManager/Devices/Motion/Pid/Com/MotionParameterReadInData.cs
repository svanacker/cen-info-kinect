namespace Org.Cen.Devices.Pid.Com
{
    using Communication.In;
    using Org.Cen.Com.In;

    public class MotionParameterReadInData : InData
    {
        public const string HEADER = "pm";

        public MotionParameterData MotionParameterData { get; private set; }

        public MotionParameterReadInData(MotionParameterData motionParameterData)
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
