namespace Org.Cen.Devices.Eeprom.Com
{
    using Cen.Com.In;
    using Communication.In;

    public class EepromReadByteInData : InData
    {
        public const string HEADER = "Er";

        public int Value { get; private set; }

        public EepromReadByteInData(int value)
            : base()
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{Value=" + Value + "}";
        }
    }
}
