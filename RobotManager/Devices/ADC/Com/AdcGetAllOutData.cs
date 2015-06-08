namespace Org.Cen.Devices.ADC.Com
{
    using Communication.Out;

    public class AdcGetAll : OutData
    {
        public const string HEADER = "dR";

        public AdcGetAll()
            : base()
        {}

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
