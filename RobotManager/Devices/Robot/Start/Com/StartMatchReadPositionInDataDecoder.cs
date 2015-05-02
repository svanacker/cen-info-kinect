namespace Org.Cen.Devices.Robot.Start.Com
{
    using Cen.Com;
    using Cen.Com.In;
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Globalization;

    public class StartMatchReadPositionInDataDecoder : IInDataDecoder
    {
        public ISet<string> GetHandledHeaders()
        {
            return new HashSet<string>() { StartMatchReadPositionInData.HEADER };
        }

        public InData Decode(string data)
        {
            // !p00-1234-5678-9012
            // config 
            string sideAsString = data.Substring(3, 2);
            MatchSide side = (MatchSide)Enum.Parse(typeof(MatchSide), sideAsString);

            // x
            string xAsString = data.Substring(6, 4);
            int x = int.Parse(xAsString, NumberStyles.HexNumber);

            // y
            string yAsString = data.Substring(11, 4);
            int y = int.Parse(yAsString, NumberStyles.HexNumber);

            // angleDeciDegree
            string angleDeciDegreeAsString = data.Substring(16, 4);
            int angleDeciDegree = int.Parse(angleDeciDegreeAsString, NumberStyles.HexNumber);

            StartMatchReadPositionInData result = new StartMatchReadPositionInData(side, x, y, angleDeciDegree);

            return result;
        }

        public int GetDataLength(string header)
        {
            return 20;
        }
    }
}
