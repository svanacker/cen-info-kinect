namespace Org.Cen.Devices.ADC.Com
{
    using Cen.Com;
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class AdcGetAllInDataDecoder : IInDataDecoder
    {
        private const int ADC_COUNT = AdcGetAllInData.DigitalValuesCount;
        private const int ACD_VALUE_LENGTH = 4;

        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { AdcGetValueInData.HEADER };
        }

        public InData Decode(string data)
        {
            int[] digitalValues = new int[ADC_COUNT];
            for (int i = 0; i < digitalValues.Length; i++)
            {
                // fixed + length + separator if any
                int offset = 3 + i*(ACD_VALUE_LENGTH + 1);
                string valueDigital0AsString = data.Substring(offset, 4);
                digitalValues[i] = int.Parse(valueDigital0AsString, NumberStyles.HexNumber);
                
            }


            AdcGetAllInData result = new AdcGetAllInData(digitalValues);
            return result;
        }

        public int GetDataLength(string header)
        {
            return 
                // fixed header size
                3 +
                // size of values
                ADC_COUNT * ACD_VALUE_LENGTH + 
                // for separators
                (ADC_COUNT - 1);
        }
    }
}
