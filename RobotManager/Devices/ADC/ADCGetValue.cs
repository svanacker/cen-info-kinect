namespace Org.Cen.Devices.ADC
{
    using Org.Cen.Communication.Out;
    using Org.Cen.Communication.Utils;

    public class AdcGetValue : OutData
    {
        public const string HEADER = "dr";
        public int ADCIndex { get; private set; }

        public AdcGetValue(int adcIndex)
            : base()
        {
            ADCIndex = adcIndex;
        }
        public override string GetArguments()
        {
            string hexADCIndex = DataParserUtils.format(ADCIndex, 2);
            string result = hexADCIndex;
            return result;
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
