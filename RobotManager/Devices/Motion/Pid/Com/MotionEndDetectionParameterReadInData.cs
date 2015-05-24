namespace Org.Cen.Devices.Pid.Com
{
    using Cen.Com.In;
    using Communication.In;

    public class MotionEndDetectionParameterReadInData : InData
    {

        public const string HEADER = "pP";

        public MotionEndDetectionParameter EndDetectionParameter { get; private set; }

        public MotionEndDetectionParameterReadInData(MotionEndDetectionParameter data)
            : base()
        {
            this.EndDetectionParameter = data;
        }

        public override string ToString()
        {
            return typeof(MotionEndDetectionParameterReadInData).Name + "{data=" + EndDetectionParameter + "}";
        }
    }
}