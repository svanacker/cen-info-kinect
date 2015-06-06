namespace Org.Cen.RobotManager.Controls.Battery
{
    using System.Windows;
    using System.Windows.Controls;
    using Devices.Battery.Com;

    /// <summary>
    /// Interaction logic for BatteryControl.xaml
    /// </summary>
    public partial class BatteryControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }


        public BatteryControl()
        {
            InitializeComponent();
        }

        private void BatteryReadButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();

            BatteryReadOutData outData = new BatteryReadOutData();
            string message = outData.GetMessage();
            Main.SendText(message);

            BatteryReadInDataDecoder decoder = new BatteryReadInDataDecoder();

            //Wait for receive all the data
            while (Main.receivedData.Length < decoder.GetDataLength(BatteryReadInData.HEADER))
            {

            }
            BatteryReadInData inData = (BatteryReadInData)decoder.Decode(Main.receivedData.ToString());

            BatteryValueLabel.Content = inData.Value.ToString();
        }
    }
}
