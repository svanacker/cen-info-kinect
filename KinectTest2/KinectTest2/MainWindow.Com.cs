namespace KinectTest2
{
    using System;
    using System.IO.Ports;
    using System.Linq;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;

    public partial class MainWindow
    {
        private const int DELAY_MS = 700;

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

            this.StartAcButton.Click += this.StartAcButton_Click;
            this.StopAcButton.Click += this.StopAcButton_Click;
        }

        private void LoadListButton_Click(object sender, RoutedEventArgs e)
        {
            string[] portNames = SerialPort.GetPortNames();
            this.COMComboBox.Items.Clear();
            foreach (string portName in portNames)
            {
                this.COMComboBox.Items.Add(portName);
            }
            this.COMComboBox.SelectedValue = portNames.FirstOrDefault();
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
            Thread.Sleep(DELAY_MS);
            this.UartManager.StopMotors();
        }

        private void BackwardMotorButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.UartManager == null)
            {
                return;
            }

            this.UartManager.BackwardMotors();
            Thread.Sleep(DELAY_MS);
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
            Thread.Sleep(DELAY_MS);
            this.UartManager.StopMotors();
        }

        private void RightMotorButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.UartManager == null)
            {
                return;
            }

            this.UartManager.RotateRight();
            Thread.Sleep(DELAY_MS);
            this.UartManager.StopMotors();
        }

        private void StartAcButton_Click(object sender, RoutedEventArgs routedEventArgs)
        {
            if (this.UartManager == null)
            {
                return;
            }

            this.UartManager.StartAc();
        }

        private void StopAcButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.UartManager == null)
            {
                return;
            }

            this.UartManager.StopAc();
        }
    }
}
