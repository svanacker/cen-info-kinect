namespace Org.Cen.RobotManager
{
    using System.Diagnostics;
    using System.IO.Ports;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using Communication.Utils.Simulation;
    using Org.Cen.Communication.Utils;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IRemoteDataReceivedEvent
    {
        // TODO : transform in private
        public StringBuilder receivedData = new StringBuilder();

        public IRemoteCommunicationManager CommunicationManager { get; private set; }

        public Process motorBoardProcess;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void SendText(string text)
        {
            if (CommunicationManager == null)
            {
                return;
            }
            CommunicationManager.WriteToRobot(text);
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

        public void OnRemoteDataReceived(string text)
        {
            receivedData.Append(text);

            // Update the contentText
            ConsolePage.UpdateInDataText(text);
        }

        private void COMComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object selectedItem = COMComboBox.SelectedItem;
            if (selectedItem == null)
            {
                return;
            }
            if (CommunicationManager != null)
            {
                CommunicationManager.Dispose();
                
            }
            // TODO Manage I2C and Simulation => Create a Factory
            CommunicationManager = new ComManager(this, selectedItem.ToString());
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPortNames();
        }

        private void AttachToRobotSimulatorButton_Click(object sender, RoutedEventArgs e)
        {
            CommunicationManager = new SerialSimulationManager(this);
        }

        private void CreateAndAttachToRobotSimulatorButton_Click(object sender, RoutedEventArgs e)
        {
            CommunicationManager = new SerialSimulationManager(this);

            // Create Process
            string fileName = @"C:\dev\git\cen-electronic\Debug\cen-electronic-console.exe";
            // string option = "motorBoardPc single";
            string option = "mainBoardPc robotManager";
            motorBoardProcess = Process.Start(fileName, option);
        }

        private void Main_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (motorBoardProcess != null)
            {
                if (CommunicationManager != null) { 
                    CommunicationManager.Dispose();
                }
                motorBoardProcess.Kill();
            }
        }
    }
}
