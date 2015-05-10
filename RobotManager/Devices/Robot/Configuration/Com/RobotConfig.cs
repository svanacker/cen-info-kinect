namespace Org.Cen.Devices.Robot.Configuration.Com
{
    using Communication.Utils;

    public class RobotConfig
    {
        private const int CONFIG_STRATEGY_MASK = 0x0007;
        private const int CONFIG_DONT_WAIT_FOR_START = 0x0008;
        private const int CONFIG_DO_NOT_END = 0x0010;
        private const int CONFIG_ROLLING_TEST_MASK = 0x0020;
        private const int CONFIG_DONT_USE_BEACON_MASK = 0x0040;
        private const int CONFIG_COLOR_GREEN_MASK = 0x00080;
        private const int CONFIG_SPEED_LOW_MASK = 0x0100;
        private const int CONFIG_SPEED_VERY_LOW_MASK = 0x0200;
        private const int CONFIG_SPEED_ULTRA_LOW_MASK = 0x0400;

        public int Value { get; set; }

        public int StrategyIndex
        {
            get { return Value & CONFIG_STRATEGY_MASK; }
            set { Value |= CONFIG_STRATEGY_MASK; }
        }

        public bool DontWaitForStart
        {
            get { return (Value & CONFIG_DONT_WAIT_FOR_START) != 0; }
            set { Value |= CONFIG_DONT_WAIT_FOR_START; }
        }

        public bool DoNotEnd
        {
            get { return (Value & CONFIG_DO_NOT_END) != 0; }
            set { Value |= CONFIG_DO_NOT_END; }
        }

        public bool RollingTest
        {
            get { return (Value & CONFIG_ROLLING_TEST_MASK) != 0; }
            set { Value |= CONFIG_ROLLING_TEST_MASK; }
        }

        public bool DontUseBeacon
        {
            get { return (Value & CONFIG_DONT_USE_BEACON_MASK) != 0; }
            set { Value |= CONFIG_DONT_USE_BEACON_MASK; }
        }

        public bool UseGreen
        {
            get { return (Value & CONFIG_COLOR_GREEN_MASK) != 0; }
            set { Value |= CONFIG_COLOR_GREEN_MASK; }
        }

        public bool SpeedLow
        {
            get { return (Value & CONFIG_SPEED_LOW_MASK) != 0; }
            set { Value |= CONFIG_SPEED_LOW_MASK; }
        }

        public bool SpeedVeryLow
        {
            get { return (Value & CONFIG_SPEED_VERY_LOW_MASK) != 0; }
            set { Value |= CONFIG_SPEED_VERY_LOW_MASK; }
        }

        public bool SpeedUltraLow
        {
            get { return (Value & CONFIG_SPEED_ULTRA_LOW_MASK) != 0; }
            set { Value |= CONFIG_SPEED_ULTRA_LOW_MASK; }
        }

        public RobotConfig(int value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return typeof(RobotConfigReadInData) + "{value=" + DataParserUtils.format(Value, 4) + "}";
        }
    }
}
