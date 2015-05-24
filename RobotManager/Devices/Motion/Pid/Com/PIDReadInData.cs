namespace Org.Cen.Devices.Pid.Com
{
    using Cen.Com.In;
    using Communication.In;

    ///
    /// Encapsulation of the message corresponding to the read of PIDData.
    /// 
    public class PIDReadInData : InData
    {
        public const string HEADER = "pr";

        public int Index { get; private set; }

        public PidData Data { get; private set; }

        public PIDReadInData(int index, PidData data)
            : base()
        {
            Index = index;
            this.Data = data;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{index=" + Index + "data=" + Data + "}";
        }
    }
}