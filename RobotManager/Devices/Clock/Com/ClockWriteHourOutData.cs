namespace Org.Cen.Devices.Clock.Com
{
    using Cen.Com.In;
    using Communication.Documentation;
    using Org.Cen.Communication.Utils;
    using Communication.Out;
    using Communication.Out.Attributes;

    [OutData(ClockWriteHourOutData.COMMAND_HEADER)]
    [DeviceParameter("hour", 2, DeviceParameterType.UNSIGNED)]
    [DeviceParameter("minute", 2, DeviceParameterType.UNSIGNED)]
    [DeviceParameter("second", 2, DeviceParameterType.UNSIGNED)]
    public class ClockWriteHourOutData : OutData
    {
        public const string HEADER = "kh";
        public const string COMMAND_HEADER = "h";

        public ClockData Clock { get; set; }

        public ClockWriteHourOutData(int hour, int minute, int second)
            : base()
        {
            Clock = new ClockData();
            this.Clock.Hour = hour;
            this.Clock.Minute = minute;
            this.Clock.Second = second;
        }

        public override string GetArguments()
        {
            string hexHourValue = DataParserUtils.format(this.Clock.Hour, 2);
            string hexMinuteValue = DataParserUtils.format(this.Clock.Minute, 2);
            string hexSecondValue = DataParserUtils.format(this.Clock.Second, 2);
            string result = hexHourValue + hexMinuteValue + hexSecondValue;
            return result;
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}
