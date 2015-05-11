namespace Org.Cen.RobotManager.Graph
{
    public class EepromDataItem
    {
        public int Index { get; set; }

        public char[] Values { get; set; }

        public char Data00
        {
            get { return Values[0]; }
        }
        public char Data01
        {
            get { return Values[1]; }
        }
        public char Data02
        {
            get { return Values[2]; }
        }
        public char Data03
        {
            get { return Values[3]; }
        }
        public char Data04
        {
            get { return Values[4]; }
        }
        public char Data05
        {
            get { return Values[5]; }
        }
        public char Data06
        {
            get { return Values[6]; }
        }
        public char Data07
        {
            get { return Values[7]; }
        }

        public EepromDataItem(int index, char[] values)
        {
            Index = index;
            Values = values;
        }
    }
}
