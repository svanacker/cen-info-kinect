namespace Org.Cen.Devices.Com
{
    using Cen.Com.In;
    using Pid.Com;

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