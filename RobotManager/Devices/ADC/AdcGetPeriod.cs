namespace Org.Cen.Devices.ADC
{
    using Org.Cen.Communication.Out;
    using Org.Cen.Communication.Utils;

    public class AdcGetPeriod : OutData
    {
        public const string HEADER = "ds";
        public int ADCIndex { get; private set; }
        public int SampleCount { get; private set; }
        public int SecondeBetweenRead { get; private set; }

        public AdcGetPeriod(int adcIndex, int sampleCount, int secondeBetweenRead)
            : base()
        {
            ADCIndex = adcIndex;
            SampleCount = sampleCount;
            SecondeBetweenRead = secondeBetweenRead;
        }
        public override string GetArguments()
        {
            string hexADCIndex = DataParserUtils.format(ADCIndex, 2);
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
