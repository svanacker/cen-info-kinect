using System.Windows;
using System.Windows.Controls;

namespace Org.Cen.RobotManager.Controls.I2C.Master
{
    using Devices.I2c.Master.Com;

    /// <summary>
    /// Interaction logic for I2cMasterUserControl.xaml
    /// </summary>
    public partial class I2cMasterUserControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public I2cMasterUserControl()
        {
            InitializeComponent();
        }

        private void EnableI2CMasterDebug(bool value)
        {
            I2CMasterDebugEnableOutData outData = new I2CMasterDebugEnableOutData(true);
            string message = outData.GetMessage();
            Main.SendText(message);
        }

        private void I2cMasterDebugEnableCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            EnableI2CMasterDebug(true);
        }

        private void I2cMasterDebugEnableCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            EnableI2CMasterDebug(false);
        }

        private void I2CMasterSendButton_Click(object sender, RoutedEventArgs e)
        {
            string textToSend = I2CMasterSendTextBox.Text;
            foreach (char c in textToSend)
            {
                I2CMasterWriteCharOutData outData = new I2CMasterWriteCharOutData(c);
                string message = outData.GetMessage();
                Main.SendText(message);
            }
        }
    }
}
