namespace Org.Cen.Devices.ADC.Com
{
    using Communication.In;
    using global::System;

    public class AdcGetAllInData : InData
    {
        public const int DigitalValuesCount = 6;

        public const string HEADER = "dr";

        public int[] DigitalValues { get; private set; }

        public AdcGetAllInData(int[] digitalValues)
        {
            if (digitalValues == null)
            {
                throw new ArgumentException("DigitalValues must not be null");
            }

            DigitalValues = digitalValues;

        }
        public override string ToString()
        {
            return GetType().Name.ToString() + "{ValueDigital0 = " + DigitalValues[0] + ", ValueDigital1 = " + DigitalValues[1] +
                ", ValueDigital2 = " + DigitalValues[2] + "ValueDigital3 = " + DigitalValues[3] + "ValueDigital4 = " + DigitalValues[4]
                + "ValueDigital5 = " + DigitalValues[5] + "}";
        }
    }
}
