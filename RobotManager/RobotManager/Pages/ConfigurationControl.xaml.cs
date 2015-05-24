namespace Org.Cen.RobotManager.Pages
{
    using System.Windows;
    using System.Windows.Controls;
    using Devices.Robot.Configuration.Com;
    using UartWPFTest;

    /// <summary>
    /// Interaction logic for ConfigurationPage.xaml
    /// </summary>
    public partial class ConfigurationControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow) Window.GetWindow(this); }
        }

        public ConfigurationControl()
        {
            InitializeComponent();
        }


        private void ConfigWriteButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            RobotConfig robotConfig = new RobotConfig(0);
            robotConfig.StrategyIndex = (int)ConfigStrategyIndexSlider.Value;
            robotConfig.DontWaitForStart = ConfigDontWaitForStartCheckBox.IsChecked != null &&
                                           ConfigDontWaitForStartCheckBox.IsChecked.Value;
            robotConfig.DoNotEnd = ConfigDontEndForStartCheckBox.IsChecked != null &&
                                           ConfigDontEndForStartCheckBox.IsChecked.Value;
            robotConfig.DontUseBeacon = ConfigDontCheckOpponentStartCheckBox.IsChecked != null &&
                                           ConfigDontCheckOpponentStartCheckBox.IsChecked.Value;
            robotConfig.RollingTest = ConfigRollingTestCheckBox.IsChecked != null &&
                                           ConfigRollingTestCheckBox.IsChecked.Value;
            robotConfig.UseGreen = ConfigGreenCheckBox.IsChecked != null &&
                                           ConfigGreenCheckBox.IsChecked.Value;
            robotConfig.SpeedLow = ConfigLowCheckBox.IsChecked != null &&
                                           ConfigLowCheckBox.IsChecked.Value;
            robotConfig.SpeedVeryLow = ConfigVeryLowCheckBox.IsChecked != null &&
                                           ConfigVeryLowCheckBox.IsChecked.Value;
            robotConfig.SpeedUltraLow = ConfigUltraLowCheckBox.IsChecked != null &&
                                           ConfigUltraLowCheckBox.IsChecked.Value;

            RobotConfigWriteOutData outData = new RobotConfigWriteOutData(robotConfig);
            string message = outData.GetMessage();
            Main.SendText(message);
        }


        private void ConfigReadButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            RobotConfigReadOutData outData = new RobotConfigReadOutData();
            string message = outData.GetMessage();
            Main.SendText(message);

            RobotConfigReadInDataDecoder decoder = new RobotConfigReadInDataDecoder();

            while (Main.receivedData.Length < decoder.GetDataLength(RobotConfigReadInData.HEADER))
            {

            }
            RobotConfigReadInData inData = (RobotConfigReadInData)decoder.Decode(Main.receivedData.ToString());
            RobotConfig config = inData.Config;

            ConfigStrategyIndexSlider.Value = config.StrategyIndex;
            StrategyIndexValueLabel.Content = config.StrategyIndex;
            ConfigDontWaitForStartCheckBox.IsChecked = config.DontWaitForStart;
            ConfigDontEndForStartCheckBox.IsChecked = config.DoNotEnd;
            ConfigDontCheckOpponentStartCheckBox.IsChecked = config.DontUseBeacon;
            ConfigRollingTestCheckBox.IsChecked = config.RollingTest;
            ConfigGreenCheckBox.IsChecked = config.UseGreen;
            ConfigLowCheckBox.IsChecked = config.SpeedLow;
            ConfigVeryLowCheckBox.IsChecked = config.SpeedVeryLow;
            ConfigUltraLowCheckBox.IsChecked = config.SpeedUltraLow;
        }
    }
}
