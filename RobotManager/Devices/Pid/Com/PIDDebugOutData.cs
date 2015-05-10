namespace Org.Cen.Devices.Pid.Com
{
    using Cen.Com.Out;
    using Communication.Utils;

    public class PidDebugOutData : OutData
    {
        private const string HEADER = "pg";

        public InstructionType InstructionType;

        /**
         * Constructor.
         */
        public PidDebugOutData(InstructionType instructionType)
            : base()
        {
            this.InstructionType = instructionType;
        }

        public override string getArguments()
        {
            string result = DataParserUtils.format((int)InstructionType, 2);
            return result;
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}
