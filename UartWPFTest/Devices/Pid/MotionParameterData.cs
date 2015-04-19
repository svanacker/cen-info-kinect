using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices.Pid.Com
{
    public class MotionParameterData
    {
        public int Acceleration { get; set; }
        public int Speed { get; set; }
        public int SpeedMax { get; set; }
        public int Time1 { get; set; }
        public int Time2 { get; set; }
        public int Time3 { get; set; }
        public int Position1 { get; set; }
        public int Position2 { get; set; }

        // TODO
        // profileType
        // motionParameterType
        // pidType
    }
}
