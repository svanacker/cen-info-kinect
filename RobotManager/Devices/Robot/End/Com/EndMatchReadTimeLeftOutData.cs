namespace Org.Cen.Devices.Robot.End.Com
{
    using Cen.Com.Out;
    using Communication.Out;

    public class EndMatchReadTimeLeftOutData : OutData
    {
        public const string HEADER = "et";

        public EndMatchReadTimeLeftOutData()
        {
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
