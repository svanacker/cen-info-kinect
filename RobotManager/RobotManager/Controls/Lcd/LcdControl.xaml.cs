using System;

using System.Windows;
using System.Windows.Controls;

namespace Org.Cen.RobotManager.Controls.Lcd
{
    using Devices.Lcd.Com;

    /// <summary>
    /// Interaction logic for LcdControl.xaml
    /// </summary>
    public partial class LcdControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public LcdControl()
        {
            InitializeComponent();
        }

        private void LcdSendButton_Click(object sender, RoutedEventArgs e)
        {
            string text = LcdTextBox.Text;

            while (text.Length > 0)
            {
                int length = Math.Min(text.Length, LcdWriteData.MESSAGE_LENGTH);
                string data = text.Substring(0, length);
                LcdWriteData outData = new LcdWriteData(length, data);
                string message = outData.GetMessage();
                Main.SendText(message);
            }
        }
    }
}
