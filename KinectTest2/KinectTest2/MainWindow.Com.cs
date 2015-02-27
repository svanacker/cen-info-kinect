namespace KinectTest2
{
    using System.IO.Ports;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;

    public partial class MainWindow
    {
        public UartManager UartManager { get; private set; }

        public void InitializeComComponent()
        {
            this.LoadListButton.Click += this.LoadListButton_Click;
            this.COMComboBox.SelectionChanged += this.COMComboBox_SelectionChanged;
            this.ForwardMotorButton.Click += this.ForwardMotorButton_Click;
            this.BackwardMotorButton.Click += this.BackwardMotorButton_Click;
            this.StopMotorButton.Click += this.StopMotorButton_Click;
            this.LeftMotorButton.Click += this.LeftMotorButton_Click;
            this.RightMotorButton.Click += this.RightMotorButton_Click;
        }

        private void LoadListButton_Click(object sender, RoutedEventArgs e)
        {
            string[] portNames = SerialPort.GetPortNames();
            this.COMComboBox.Items.Clear();
            foreach (string portName in portNames)
            {
                this.COMComboBox.Items.Add(portName);
            }
        }

        private void COMComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object selectedItem = this.COMComboBox.SelectedItem;
            if (selectedItem == null)
            {
                return;
            }

            if (this.UartManager != null)
            {
                this.UartManager.Close();
            }

            var portName = selectedItem.ToString();
            this.UartManager = new UartManager(portName);
            this.UartManager.Open();
        }

        private void ForwardMotorButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.UartManager == null)
            {
                return;
            }

            this.UartManager.RunMotors();
            Thread.Sleep(1000);
            this.UartManager.StopMotors();
        }

        private void BackwardMotorButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.UartManager == null)
            {
                return;
            }

            this.UartManager.BackwardMotors();
            Thread.Sleep(1000);
            this.UartManager.StopMotors();
        }

        private void StopMotorButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.UartManager == null)
            {
                return;
            }

            this.UartManager.StopMotors();

        }

        private void LeftMotorButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.UartManager == null)
            {
                return;
            }

            this.UartManager.RotateLeft();
            Thread.Sleep(1000);
            this.UartManager.StopMotors();
        }

        private void RightMotorButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.UartManager == null)
            {
                return;
            }

            this.UartManager.RotateRight();
            Thread.Sleep(1000);
            this.UartManager.StopMotors();
        }
    }
}
