namespace Org.Cen.Devices.Navigation.Com
{
    using Cen.Com;
    using Communication.In;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class NavigationLocationListCountInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { NavigationLocationListCountInData.HEADER };
        }

        public InData Decode(string data)
        {
            // Nd01234
            string countAsString = data.Substring(3, 4);
            int count = int.Parse(countAsString, NumberStyles.HexNumber);


            NavigationLocationListCountInData result = new NavigationLocationListCountInData(count);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 7;
        }
    }
}
