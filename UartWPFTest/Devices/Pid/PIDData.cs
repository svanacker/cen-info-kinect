using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices.Pid
{
    public class PIDData
    {
        public int P { get; set; }
        public int I { get; set; }
        public int D { get; set; }
        public int MaxI { get; set; }
    }
}
