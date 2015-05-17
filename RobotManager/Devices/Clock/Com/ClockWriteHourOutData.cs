using System;
using Org.Cen.Communication.Utils;

namespace Org.Cen.Devices.Clock.Com
{
    using Cen.Com.Out;
    public class ClockWriteHourOutData : OutData
    {
        public const string HEADER = "kh";

        public ClockData Clock { get; set; }

        public ClockWriteHourOutData(int hour, int minute, int second)
            : base()
        {
            Clock = new ClockData();
            this.Clock.Hour = hour;
            this.Clock.Minute = minute;
            this.Clock.Second = second;
        }

        public override string getArguments()
        {
            string hexHourValue = DataParserUtils.format(this.Clock.Hour, 2);
            string hexMinuteValue = DataParserUtils.format(this.Clock.Minute, 2);
            string hexSecondValue = DataParserUtils.format(this.Clock.Second, 2);
            string result = hexHourValue + hexMinuteValue + hexSecondValue;
            return result;
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}
