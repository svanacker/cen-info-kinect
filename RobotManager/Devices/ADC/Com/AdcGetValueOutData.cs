namespace Org.Cen.Devices.ADC.Com
{
    using Communication.Out;
    using Communication.Utils;

    public class AdcGetValueOutData : OutData
    {
        public const string HEADER = "dr";
        public int AdcIndex { get; private set; }

        public AdcGetValueOutData(int adcIndex)
            : base()
        {
            AdcIndex = adcIndex;
        }
        public override string GetArguments()
        {
            string hexADCIndex = DataParserUtils.format(AdcIndex, 2);
            string result = hexADCIndex;
            return result;
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
