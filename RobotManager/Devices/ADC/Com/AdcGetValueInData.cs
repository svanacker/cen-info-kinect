namespace Org.Cen.Devices.ADC.Com
{
    using Communication.In;

    public class AdcGetValueInData : InData
    {
        public const string HEADER = "dr";

        public int DigitalValue { get; private set; }

        public AdcGetValueInData(int digitalValue)
        {
            DigitalValue = digitalValue;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{Digital Value =" + DigitalValue + "}";
        }
    }
}
