using Devices.Pid;
using Org.Cen.Com.Out;
using Org.Cen.Com.Utils;

namespace Org.Cen.Devices.Motion.Position.Com
{

/**
 * The encapsulation of the data which must be sent to clear the wheel positions.
 */

    public class ClearPositionOutData : OutData
    {

        /** The Header which is used by the message to change the PID. */
        public const string HEADER = "wc";

        /**
     * Constructor
     */

        public ClearPositionOutData()
            : base()
        {
        }

        public override string getArguments()
        {
            return "";
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}