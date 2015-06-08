namespace Org.Cen.Devices.ADC.Com
{
    using Cen.Com;
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class AdcGetAllInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { AdcGetValueInData.HEADER };
        }

        public InData Decode(string data)
        {
            string valueDigital0AsString = data.Substring(3, 4);
            int valueDigital0 = int.Parse(valueDigital0AsString, NumberStyles.HexNumber);

            string valueDigital1AsString = data.Substring(8, 4);
            int valueDigital1 = int.Parse(valueDigital1AsString, NumberStyles.HexNumber);

            string valueDigital2AsString = data.Substring(13, 4);
            int valueDigital2 = int.Parse(valueDigital2AsString, NumberStyles.HexNumber);

            string valueDigital3AsString = data.Substring(18, 4);
            int valueDigital3 = int.Parse(valueDigital3AsString, NumberStyles.HexNumber);

            string valueDigital4AsString = data.Substring(23, 4);
            int valueDigital4 = int.Parse(valueDigital4AsString, NumberStyles.HexNumber);

            string valueDigital5AsString = data.Substring(28, 4);
            int valueDigital5 = int.Parse(valueDigital5AsString, NumberStyles.HexNumber);

            AdcGetAllInData result = new AdcGetAllInData(valueDigital0, valueDigital1, valueDigital2, valueDigital3, valueDigital4, valueDigital5);
            return result;
        }

        public int GetDataLength(string header)
        {
            return 32;
        }
    }
}
