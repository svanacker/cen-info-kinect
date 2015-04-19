using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices.Pid
{
    public class PIDDebugData
    {
        public int InstructionType { get; set; }
        public int PidTime { get; set; }
        public int PidType { get; set; }
        public int Position { get; set; }
        public int Error { get; set; }
        public int U { get; set; }
        public int EndMotionIntegralTime { get; set; }
        public int EndMotionAbsDeltaPositionIntegral { get; set; }
        public int EndMotionUIntegral { get; set; }
    }
}
