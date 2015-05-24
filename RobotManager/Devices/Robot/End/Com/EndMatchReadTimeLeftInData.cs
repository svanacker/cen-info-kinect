namespace Org.Cen.Devices.Robot.End.Com
{
    using Cen.Com.In;
    using Communication.In;

    public class EndMatchReadTimeLeftInData : InData
    {
        public const string HEADER = "et";

        public int TimeLeft { get; private set; }

        public EndMatchReadTimeLeftInData(int timeLeft)
            : base()
        {
            TimeLeft = timeLeft;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{timeLeft=" + TimeLeft + "}";
        }
    }
}
