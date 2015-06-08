namespace Org.Cen.Devices.ADC.Com
{
    using Communication.In;
    public class AdcGetValueInData : InData
    {
        public const string HEADER = "dr";
        public int ValueDigital { get; private set; }

        public AdcGetValueInData(int valueDigital)
        {
            ValueDigital = valueDigital;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{Value digital =" + ValueDigital + "}";
        }
    }
}
