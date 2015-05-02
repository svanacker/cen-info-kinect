namespace Org.Cen.Devices.Robot.End.Com
{
    using Cen.Com.Out;

    public class EndMatchReadTimeLeftOutData : OutData
    {
        public const string HEADER = "et";

        public EndMatchReadTimeLeftOutData()
        {
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}
