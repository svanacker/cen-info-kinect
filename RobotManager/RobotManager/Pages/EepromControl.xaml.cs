namespace Org.Cen.RobotManager.Pages
{
    using System;
    using System.IO;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;

    using Devices.Eeprom.Com;
    using Graph;
    using UartWPFTest;

    /// <summary>
    /// Interaction logic for EepromControl.xaml
    /// </summary>
    public partial class EepromControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public EepromControl()
        {
            InitializeComponent();
        }

        private void ReadByteEepromButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();

            int address = int.Parse(EepromAddressTextBox.Text);

            EepromReadByteOutData outData = new EepromReadByteOutData(address);
            string message = outData.getMessage();
            Main.SendText(message);

            EepromReadByteInDataDecoder decoder = new EepromReadByteInDataDecoder();

            while (Main.receivedData.Length < decoder.GetDataLength(EepromReadByteInData.HEADER))
            {

            }
            EepromReadByteInData inData = (EepromReadByteInData)decoder.Decode(Main.receivedData.ToString());

            EepromDataTextBox.Text = inData.Value.ToString();
        }

        private void WriteByteEepromButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            int address = int.Parse(EepromAddressTextBox.Text);
            int value = int.Parse(EepromDataTextBox.Text);
            EepromWriteByteOutData outData = new EepromWriteByteOutData(address, value);
            string message = outData.getMessage();
            Main.SendText(message);
        }

        private EepromReadByteBlockInData ReadBlockEeprom(int address, bool updateGrid)
        {
            EepromReadByteBlockOutData outData = new EepromReadByteBlockOutData(address);
            string message = outData.getMessage();
            Main.SendText(message);

            EepromReadByteBlockInDataDecoder decoder = new EepromReadByteBlockInDataDecoder();

            while (Main.receivedData.Length < decoder.GetDataLength(EepromReadByteBlockInData.HEADER))
            {

            }
            EepromReadByteBlockInData inData = (EepromReadByteBlockInData)decoder.Decode(Main.receivedData.ToString());
            Main.receivedData.Remove(0, decoder.GetDataLength(EepromReadByteBlockInData.HEADER));

            if (updateGrid)
            {
                bool hexa = EepromHexCheckBox.IsChecked.GetValueOrDefault(true);
                EepromDataItem dataItem = new EepromDataItem(hexa, address, inData.Values);
                Main.Eeprom.EepromDataGrid.Items.Add(dataItem);
            }

            return inData;
        }

        private void ReadByteBlockEepromButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();

            int address = int.Parse(EepromAddressTextBox.Text);

            ReadBlockEeprom(address, true);
        }

        private void WriteByteBlockEepromButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReadAllEepromButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();

            Main.Eeprom.EepromDataGrid.Items.Clear();
            const int width = EepromReadByteBlockInData.EEPROM_DEVICE_READ_BLOCK_LENGTH;
            for (int address = 0; address < EepromReadByteBlockInData.EEPROM_DEVICE_MAX_ADDRESS; address += width)
            {
                ReadBlockEeprom(address, true);
            }
        }

        private void EepromDumpButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            const int width = EepromReadByteBlockInData.EEPROM_DEVICE_READ_BLOCK_LENGTH;

            string fileName = EepromFilePathTextBox.Text;

            // Rename the existing file !
            bool fileExist = File.Exists(fileName);
            
            if (fileExist)
            {
                DateTime dateTime = DateTime.Now;
                string dateTimeAsString = dateTime.ToString("yyyy-MM-dd__HH-mm-ss");
                File.Move(fileName, fileName + "." + dateTimeAsString);
            }

            using (StreamWriter streamWriter = new StreamWriter(File.Open(fileName, FileMode.Create), Encoding.ASCII))
            {
                for (int address = 0; address < EepromReadByteBlockInData.EEPROM_DEVICE_MAX_ADDRESS; address += width)
                {
                    EepromReadByteBlockInData inData = ReadBlockEeprom(address, true);
                    streamWriter.Write(inData.Values);
                }
            }
        }

        private void EepromLoadButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            string fileName = EepromFilePathTextBox.Text;
            using (StreamReader streamReader = new StreamReader(File.Open(fileName, FileMode.Open), Encoding.ASCII))
            {
                const int width = EepromWriteByteBlockOutData.EEPROM_DEVICE_WRITE_BLOCK_LENGTH;
                for (int address = 0; address < EepromReadByteBlockInData.EEPROM_DEVICE_MAX_ADDRESS; address += width)
                {
                    char[] values = new char[width];
                    streamReader.Read(values, 0, width);
                    EepromWriteByteBlockOutData outData = new EepromWriteByteBlockOutData(address, values);
                    string message = outData.getMessage();
                    Main.SendText(message);

                    // Wait for ACK : TODO : Check if we have to synchronize data
                    int responseLength = EepromWriteByteBlockInData.HEADER.Length + 1;
                    while (Main.receivedData.Length < responseLength)
                    {

                    }
                    Main.receivedData.Remove(0, responseLength);
                }
            }
        }

        private void EepromHexCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Main == null || Main.Eeprom == null)
            {
                return;
            }
            bool hexa = EepromHexCheckBox.IsChecked.GetValueOrDefault(true);
            foreach (var item in Main.Eeprom.EepromDataGrid.Items)
            {
                EepromDataItem dataItem = (EepromDataItem) item;
                dataItem.Hexa = hexa;
            }
            Main.Eeprom.EepromDataGrid.UpdateLayout();
        }
    }
}
