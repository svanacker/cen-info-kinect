namespace Org.Cen.RobotManager.Controls.Lcd
{
    using Devices.Lcd.Com;
    using System;

    using System.Windows;
    using System.Windows.Controls;

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
            int textLength = text.Length;
            int textSend = 0;

            while (textLength != 0)
            {
                int length = Math.Min(textLength, LcdWriteData.MESSAGE_LENGTH);
                string data = text.Substring(textSend, length);
                LcdWriteData outData = new LcdWriteData(data);
                string message = outData.GetMessage();
                Main.SendText(message);
                textSend += length;
                textLength -= length;
            }
        }
        private void LcdClearButton_Click(object sender, RoutedEventArgs e)
        {
            LcdClearData outData = new LcdClearData();
            string messageClear = outData.GetMessage();
            Main.SendText(messageClear);
        }
    }
}
