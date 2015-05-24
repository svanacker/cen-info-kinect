namespace Org.Cen.Devices.Motion.Simulation.Com
{
    using Cen.Com.Out;
    using Communication.Out;

    ///
    /// The encapsulation of the data which must be sent to read the simulation Parameters.
    ///
    public class MotionSimulationReadOutData : OutData
    {
        /// <summary>
        /// The Header which is used by the message to read the simulation Parameters.
        /// </summary>
        public const string HEADER = "/r";

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}