﻿namespace Org.Cen.RobotManager.Pages
{
    using System.Windows;
    using System.Windows.Controls;

    using Devices.Eeprom.Com;
    using UartWPFTest;

    /// <summary>
    /// Interaction logic for EepromPage.xaml
    /// </summary>
    public partial class EepromPage : Page
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public EepromPage()
        {
            InitializeComponent();
        }
    
        private void ReadEepromButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();

            int address = int.Parse(EepromAddressTextBox.Text);

            EepromReadByteOutData outData = new EepromReadByteOutData(address);
            string message = outData.getMessage();
            Main.SendText(message);

            EepromReadInDataDecoder decoder = new EepromReadInDataDecoder();

            while (Main.receivedData.Length < decoder.GetDataLength(EepromReadInData.HEADER))
            {

            }
            EepromReadInData inData = (EepromReadInData)decoder.Decode(Main.receivedData.ToString());

            EepromDataTextBox.Text = inData.Value.ToString();
        }

        private void WriteEepromButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            int address = int.Parse(EepromAddressTextBox.Text);
            int value = int.Parse(EepromDataTextBox.Text);
            EepromWriteOutData outData = new EepromWriteOutData(address, value);
            string message = outData.getMessage();
            Main.SendText(message);
        }

        private void EepromGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Main.Eeprom = this;
        }
    }
}
