using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartWPFTest
{
    public class MotionDataItem
    {
        public int PidTime { get; set; }
        public int NormalPosition { get; set; }
        public int NormalSpeed { get; set; }
        public int Position { get; set; }
        public int Speed { get; set; }
    }
}
