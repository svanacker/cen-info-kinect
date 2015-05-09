namespace UartWPFTest
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Pipes;
    using System.Linq;
    using System.Security.Principal;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;

    using System.IO.Ports;
    using System.Security.AccessControl;
    using Org.Cen.Communication.I2c;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SerialPort currentPort;

        // TODO : transform in private
        public StringBuilder receivedData = new StringBuilder();

        private StreamWriter pipeWriter;
        private StreamReader pipeReader;

        public Process motorBoardProcess;

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
            if (pipeWriter != null)
            {
                try
                {
                    I2CManager.SendToSlave(pipeWriter, text);
                }
                catch (Exception ex)
                {
                    ConsolePage.ContentTextBox.Text += ex.StackTrace.ToString();
                }
            }

            if (currentPort == null)
            {
                return;
            }
            currentPort.WriteLine(text);
            // we add some line return so that we can read easily the return of the remote board
            ConsolePage.ContentTextBox.Text += text + "\n";
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
            ConsolePage.UpdateInDataText(newText);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPortNames();
        }

        private void CreateMotorBoardServerPipe()
        {
            // Server
            Task.Run(() =>
            {
                var sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                var rule = new PipeAccessRule(sid, PipeAccessRights.ReadWrite, AccessControlType.Allow);
                var sec = new PipeSecurity();
                sec.AddAccessRule(rule);

                var server = new NamedPipeServerStream("mainBoardPipe", PipeDirection.InOut, 1,
                    PipeTransmissionMode.Byte, PipeOptions.None, 100, 100, sec);
                server.WaitForConnection();
                pipeWriter = new StreamWriter(server, Encoding.ASCII);
                pipeWriter.AutoFlush = true;

            });
        }

        private void CreateMotorBoardClientPipe()
        {
            // Client
            Task.Run(() =>
            {
                var client = new NamedPipeClientStream("motorBoardPipe");
                client.Connect();
                pipeReader = new StreamReader(client, Encoding.ASCII);
                while (true)
                {
                    if (pipeReader == null)
                    {
                        break;
                    }
                    char value = (char)pipeReader.Read();
                    // No Control Char
                    if (!Char.IsControl(value))
                    {
                        receivedData.Append(value);
                        ConsolePage.UpdateInDataText(Char.ToString(value));
                    }
                }
            });

            // Server
            Task.Run(() =>
            {

                while (true)
                {
                    if (pipeReader != null)
                    {
                        Thread.Sleep(10);
                        I2CManager.AskToSendDataFromSlaveToMaster(pipeWriter);
                    }
                }
            });
        }

        private void AttachToRobotSimulatorButton_Click(object sender, RoutedEventArgs e)
        {
            CreateMotorBoardServerPipe();
            CreateMotorBoardClientPipe();
        }

        private void CreateAndAttachToRobotSimulatorButton_Click(object sender, RoutedEventArgs e)
        {
            CreateMotorBoardServerPipe();
            CreateMotorBoardClientPipe();
            // Create Process
            motorBoardProcess = Process.Start(@"C:\dev\git\cen-electronic\Debug\cen-electronic-console.exe", "motorBoardPc single");
        }

        private void Main_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (motorBoardProcess != null)
            {
                if (pipeReader != null)
                {
                    pipeReader.Dispose();
                    pipeReader = null;
                }
                if (pipeWriter != null) { 
                    pipeWriter.Dispose();
                    pipeWriter = null;
                }
                motorBoardProcess.Kill();
            }
        }
    }
}
