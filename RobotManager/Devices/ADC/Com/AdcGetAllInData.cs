namespace Org.Cen.Devices.ADC.Com
{
    using Communication.In;

    public class AdcGetAllInData : InData
    {
        public const string HEADER = "dr";

        public int ValueDigital0 { get; private set; }
        public int ValueDigital1 { get; private set; }
        public int ValueDigital2 { get; private set; }
        public int ValueDigital3 { get; private set; }
        public int ValueDigital4 { get; private set; }
        public int ValueDigital5 { get; private set; }

        public AdcGetAllInData(int valueDigital0, int valueDigital1, int valueDigital2, int valueDigital3,
            int valueDigital4, int valueDigital5)
        {
            ValueDigital0 = valueDigital0;
            ValueDigital1 = valueDigital1;
            ValueDigital2 = valueDigital2;
            ValueDigital3 = valueDigital3;
            ValueDigital4 = valueDigital4;
            ValueDigital5 = valueDigital5;
        }
        public override string ToString()
        {
            return GetType().Name.ToString() + "{ValueDigital0 = " + ValueDigital0 + "ValueDigital1 = " + ValueDigital1 + "ValueDigital2 = " + ValueDigital2 + "ValueDigital3 = " + ValueDigital3 + "ValueDigital4 = " + ValueDigital4 + "ValueDigital5 = " + ValueDigital5 + "}";
        }
    }
}
