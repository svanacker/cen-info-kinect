using System.Globalization;

namespace Org.Cen.Devices.ADC.Com
{
    using Cen.Com;
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class AdcGetValueInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { AdcGetValueInData.HEADER };
        }

        public InData Decode(string data)
        {
            string valueDigitalAsString = data.Substring(3, 4);
            int valueDigital = int.Parse(valueDigitalAsString, NumberStyles.HexNumber);
            AdcGetValueInData result = new AdcGetValueInData(valueDigital);
            return result;
        }

        public int GetDataLength(string header)
        {
            return 7;
        }
    }
}
