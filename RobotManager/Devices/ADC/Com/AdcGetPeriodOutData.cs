namespace Org.Cen.Devices.ADC.Com
{
    using Communication.Out;
    using Communication.Utils;

    public class AdcGetPeriodOutData : OutData
    {
        public const string HEADER = "ds";
        public int AdcIndex { get; private set; }
        public int SampleCount { get; private set; }
        public int SecondeBetweenRead { get; private set; }

        public AdcGetPeriodOutData(int adcIndex, int sampleCount, int secondeBetweenRead)
            : base()
        {
            AdcIndex = adcIndex;
            SampleCount = sampleCount;
            SecondeBetweenRead = secondeBetweenRead;
        }
        public override string GetArguments()
        {
            string hexADCIndex = DataParserUtils.format(AdcIndex, 2);
            string hexSampleCount = DataParserUtils.format(SampleCount, 2);
            string hexSecondeBetweenRead = DataParserUtils.format(SecondeBetweenRead, 2);
            string result = hexADCIndex + hexSampleCount + hexSecondeBetweenRead;
            return result;
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
