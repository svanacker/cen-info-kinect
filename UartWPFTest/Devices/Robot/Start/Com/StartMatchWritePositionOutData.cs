namespace Org.Cen.Devices.Robot.Start.Com
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;
    using Cen.Com.Out;
    using Cen.Com.Utils;

    public class StartMatchWritePositionOutData : OutData
    {
        public const string HEADER = "!P";

        public MatchSide Side { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int AngleDeciDegree { get; private set; }

        public StartMatchWritePositionOutData(MatchSide matchSide, int x, int y, int angleDeciDegree)
        {
            Side = matchSide;
            X = x;
            Y = y;
            AngleDeciDegree = angleDeciDegree;
        }

        public override string getArguments()
        {
            StringBuilder result = new StringBuilder();

            // !p01-1234-5678-9012
            string sideAsString = ComDataUtils.format((int)(Side), 2);
            result.Append(sideAsString);
            result.Append("-");

            // x
            string xAsString = ComDataUtils.format(X, 4);
            result.Append(xAsString);
            result.Append("-");

            // y
            string yAsString = ComDataUtils.format(Y, 4);
            result.Append(yAsString);
            result.Append("-");

            // angleDeciDegree
            string angleDeciDegreeAsString = ComDataUtils.format(AngleDeciDegree, 4);
            result.Append(angleDeciDegreeAsString);

            return result.ToString();
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}
