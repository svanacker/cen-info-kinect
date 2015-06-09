namespace Org.Cen.Devices.ADC.Com
{
    using Communication.Out;

    public class AdcGetAllOutData : OutData
    {
        public const string HEADER = "dR";

        public AdcGetAllOutData()
            : base()
        {}

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
