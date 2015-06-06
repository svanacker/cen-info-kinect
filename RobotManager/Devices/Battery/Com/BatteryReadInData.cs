namespace Org.Cen.Devices.Battery.Com
{
    using Communication.In;

    public class BatteryReadInData : InData
    {
        public const string HEADER = "br";

        public int Value { get; private set; }

        public BatteryReadInData(int value)
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
