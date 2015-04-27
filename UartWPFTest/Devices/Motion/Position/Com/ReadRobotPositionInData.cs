using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.Com.Devices.Motion.Position.Com
{
    using Cen.Com.In;

    public class ReadRobotPositionInData : InData
    {

        public const string HEADER = "nr";

        public RobotPosition Position { get; private set; }

        public ReadRobotPositionInData(RobotPosition position)
            : base()
        {
            this.Position = position;
        }

        public override string ToString()
        {
            return GetType().Name.ToString() + "{position=" + Position + "}";
        }
    }
}
