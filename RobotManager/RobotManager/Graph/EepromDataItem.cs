namespace Org.Cen.RobotManager.Graph
{
    using Communication.Utils;

    public class EepromDataItem
    {
        public bool Hexa { get; set; }

        public int Index
        {
            get;
            private set;
        }

        public string FormattedIndex
        {
            get { return GetFormattedValue(Index, 4); }
        }

        public char[] Values { get; private set; }

        private string GetFormattedValue(int value, int length)
        {
            if (Hexa)
            {
                return DataParserUtils.format(value, length);
            }
            else
            {
                return value.ToString();
            }
        }

        public string Data00
        {
            get { return GetFormattedValue(Values[0], 2); }
        }

        public string Data01
        {
            get { return GetFormattedValue(Values[1], 2); }
        }

        public string Data02
        {
            get { return GetFormattedValue(Values[2], 2); }
        }

        public string Data03
        {
            get { return GetFormattedValue(Values[3], 2); }
        }

        public string Data04
        {
            get { return GetFormattedValue(Values[4], 2); }
        }

        public string Data05
        {
            get { return GetFormattedValue(Values[5], 2); }
        }

        public string Data06
        {
            get { return GetFormattedValue(Values[6], 2); }
        }

        public string Data07
        {
            get { return GetFormattedValue(Values[7], 2); }
        }

        public EepromDataItem(bool hexa, int index, char[] values)
        {
            Hexa = hexa;
            Index = index;
            Values = values;
        }
    }
}
