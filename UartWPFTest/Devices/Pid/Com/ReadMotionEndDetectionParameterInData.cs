namespace Org.Cen.Devices.Pid.Com
{
    using Cen.Com.In;

    public class ReadMotionEndDetectionParameterInData : InData
    {

        public const string HEADER = "pP";

        public MotionEndDetectionParameter EndDetectionParameter { get; private set; }

        public ReadMotionEndDetectionParameterInData(MotionEndDetectionParameter data)
            : base()
        {
            this.EndDetectionParameter = data;
        }

        public override string ToString()
        {
            return typeof(ReadMotionEndDetectionParameterInData).Name + "{data=" + EndDetectionParameter + "}";
        }
    }
}