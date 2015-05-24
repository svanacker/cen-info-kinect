namespace Org.Cen.Devices.Pid.Com
{
    using Cen.Com.In;
    using Communication.In;

    /**
     * Encapsulation of the message corresponding to the read of data to debug it.
     */
    public class PIDDebugInData : InData
    {

        public const string HEADER = "pg";

        public PIDDebugData PIDDebugData { get; private set; }

        public PIDDebugInData(PIDDebugData PIDDebugData)
            : base()
        {
            this.PIDDebugData = PIDDebugData;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{data=" + PIDDebugData + "}";
        }
    }
}