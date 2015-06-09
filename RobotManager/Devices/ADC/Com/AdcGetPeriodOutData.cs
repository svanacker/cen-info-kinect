namespace Org.Cen.Devices.ADC.Com
{
    using Communication.Out;
    using Communication.Utils;

    public class AdcGetPeriodOutData : OutData
    {
        public const string HEADER = "ds";

        public int AdcIndex { get; private set; }
        public int SampleCount { get; private set; }
        public int SecondsBetweenRead { get; private set; }

        public AdcGetPeriodOutData(int adcIndex, int sampleCount, int secondsBetweenRead)
            : base()
        {
            AdcIndex = adcIndex;
            SampleCount = sampleCount;
            SecondsBetweenRead = secondsBetweenRead;
        }
        public override string GetArguments()
        {
            string hexAdcIndex = DataParserUtils.format(AdcIndex, 2);
            string hexSampleCount = DataParserUtils.format(SampleCount, 2);
            string hexSecondeBetweenRead = DataParserUtils.format(SecondsBetweenRead, 2);
            string result = hexAdcIndex + "-" + hexSampleCount + "-" + hexSecondeBetweenRead;
            return result;
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
