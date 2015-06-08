namespace Org.Cen.Devices.Lcd.Com
{
    using Communication.Out;

    public class LcdClearData : OutData
    {
        public const string HEADER = "Lc";

        public LcdClearData()
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
