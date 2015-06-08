namespace Org.Cen.Devices.ADC
{
    using Org.Cen.Communication.Out;
    using Org.Cen.Communication.Utils;

    public class AdcGetAll : OutData
    {
        public const string HEADER = "dR";

        public AdcGetAll()
            : base()
        {
        }
        public override string GetArguments()
        {
            return "";
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
