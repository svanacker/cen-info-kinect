namespace Org.Cen.Devices.Navigation.Com
{
    using Cen.Com;
    using Communication.In;
    using Communication.Utils;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class NavigationLocationReadInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { NavigationLocationReadInData.HEADER };
        }

        public InData Decode(string data)
        {
            // aNl30000000-0001-0002
            string locationName = data.Substring(3, 8);

            string xAsString = data.Substring(12, 4);
            long x = DataParserUtils.parseIntHex(xAsString);

            string yAsString = data.Substring(17, 4);
            long y = DataParserUtils.parseIntHex(yAsString);

            Location location = new Location(locationName, (int) x, (int) y);
            NavigationLocationReadInData result = new NavigationLocationReadInData(location);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 21;
        }
    }
}
