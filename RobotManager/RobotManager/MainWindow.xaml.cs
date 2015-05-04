namespace UartWPFTest
{
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;

    using System.IO.Ports;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SerialPort currentPort;

        // TODO : transform in private
        public StringBuilder receivedData = new StringBuilder();

        /*
        public ConsoleControl Console { get; set; }
        public ConfigurationControl Configuration { get; set; }
        public EepromControl Eeprom { get; set; }
        public EndDetectionParametersControl EndDetectionParameters { get; set; }
        public MatchControl Match { get; set; }
        public MotionGraphControl MotionGraph { get; set; }
        public MotionParametersControl MotionParameters { get; set; }
        public PIDGraphControl PIDGraph { get; set; }
        public PositionControl Position { get; set; }
        public RawDataControl RawData { get; set; }
        public RunControl Run { get; set; }
        public GameBoardControl GameBoard { get; set; }
        */

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPort == null)
            {
                return;
            }
            currentPort.Close();
        }


        public void SendText(string text)
        {
            if (currentPort == null)
            {
                return;
            }
            currentPort.WriteLine(text);
            // we add some line return so that we can read easily the return of the remote board
            Console.ContentTextBox.Text += text + "\n";
        }

        private void LoadPortNames()
        {
            string[] portNames = SerialPort.GetPortNames();
            COMComboBox.Items.Clear();
            foreach (string portName in portNames)
            {
                COMComboBox.Items.Add(portName);
            }
        }

        private void LoadListButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPortNames();
        }

        private void COMComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object selectedItem = COMComboBox.SelectedItem;
            if (selectedItem == null)
            {
                return;
            }
            if (currentPort != null && currentPort.IsOpen)
            {
                currentPort.Close();
                currentPort.DataReceived -= UartReceive;
            }
            currentPort = new SerialPort(selectedItem.ToString(), 115200, Parity.None, 8, StopBits.One);
            currentPort.Open();
            currentPort.DataReceived += UartReceive;
        }

        private void UartReceive(object sender, SerialDataReceivedEventArgs e)
        {
            if (currentPort == null)
            {
                return;
            }
            int bytesToRead = currentPort.BytesToRead;
            if (bytesToRead == 0)
            {
                return;
            }

            byte[] buffer = new byte[bytesToRead];
            currentPort.Read(buffer, 0, bytesToRead);

            string newText = Encoding.ASCII.GetString(buffer, 0, bytesToRead);

            receivedData.Append(newText);

            // Update the contentText
            Console.UpdateInDataText(newText);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPortNames();
        }
    }
}
