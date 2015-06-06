namespace Org.Cen.Devices.System.Com
{
    using Communication.In;

    public class SystemGetLastErrorInData : InData
    {
        public const string HEADER = SystemGetLastErrorOutData.HEADER;

        public int LastError { get; private set; }

        public SystemGetLastErrorInData(int lastError)
            : base()
        {
            this.LastError = lastError;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{LastError=" + LastError + "}";
        }
    }
}
