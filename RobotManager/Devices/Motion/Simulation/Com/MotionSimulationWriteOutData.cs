namespace Org.Cen.Devices.Motion.Simulation.Com
{
    using Cen.Com.Out;
    using Communication.Out;
    using Communication.Utils;
    using global::System.Text;

    ///
    /// The encapsulation of the data which must be sent to write the simulation Parameters.
    ///
    public class MotionSimulationWriteOutData : OutData
    {
        /// <summary>
        /// The Header which is used by the message to write the simulation Parameters.
        /// </summary>
        public const string HEADER = "/w";

        public MotionSimulationData SimulationData { get; private set; }

        public MotionSimulationWriteOutData(MotionSimulationData motionSimulationData)
            : base()
        {
            SimulationData = motionSimulationData;
        }

        public override string GetArguments()
        {
            StringBuilder result = new StringBuilder();

            result.Append(DataParserUtils.format(SimulationData.Motors));
            result.Append(DataParserUtils.format(SimulationData.Coders));
            result.Append(DataParserUtils.format(SimulationData.Position));
            return result.ToString();
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}