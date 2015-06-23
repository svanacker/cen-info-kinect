namespace Org.Cen.Devices.Lcd.Com
{
    using Communication.Out;

    public class LcdClearOutData : OutData
    {
        public const string HEADER = "Lc";

        public LcdClearOutData()
            : base()
        {
            
        }

        public override string GetArguments()
        {
            return ""; 
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
