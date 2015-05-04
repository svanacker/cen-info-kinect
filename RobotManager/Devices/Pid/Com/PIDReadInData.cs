namespace Org.Cen.Devices.Pid.Com
{
    using Cen.Com.In;

    /**
     * Encapsulation of the message corresponding to the read of PIDData.
     */
    public class PIDReadInData : InData
    {

        public const string HEADER = "q";

        private PidData data;

        public PIDReadInData(PidData data)
            : base()
        {
            this.data = data;
        }

        public PidData getData()
        {
            return data;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{data=" + data + "}";
        }
    }
}