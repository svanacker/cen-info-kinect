
namespace UartWPFTest
{
    using System;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using System.IO.Ports;
    using Org.Cen.Com.Utils;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SerialPort currentPort;

        private const int COM_INPUT_COUNT = 10;

        private InputHistory[] inputHistories = new InputHistory[COM_INPUT_COUNT];

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < COM_INPUT_COUNT; i++)
            {
                inputHistories[i] = new InputHistory();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPort == null)
            {
                return;
            }
            currentPort.Close();
        }

        private TextBox GetLinkedTextBox(Button sendButton)
        {
            if (SendButton1 == sendButton) { return SendTextBox1; }
            if (SendButton2 == sendButton) { return SendTextBox2; }
            if (SendButton3 == sendButton) { return SendTextBox3; }
            if (SendButton4 == sendButton) { return SendTextBox4; }
            if (SendButton5 == sendButton) { return SendTextBox5; }
            if (SendButton6 == sendButton) { return SendTextBox6; }
            if (SendButton7 == sendButton) { return SendTextBox7; }
            if (SendButton8 == sendButton) { return SendTextBox8; }
            if (SendButton9 == sendButton) { return SendTextBox9; }
            if (SendButton10 == sendButton) { return SendTextBox10; }
            return null;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            if (senderButton == null)
            {
                return;
            }
            TextBox textBox = GetLinkedTextBox(senderButton);
            string text = textBox.Text;
            SendText(text);
            InputHistory inputHistory = GetInputHistory(textBox);
            inputHistory.AddEntry(text);
        }

        private void SendText(string text)
        {
            if (currentPort == null)
            {
                return;
            }
            currentPort.WriteLine(text);
            // we add some line return so that we can read easily the return of the remote board
            ContentTextBox.Text += "\n";
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ContentTextBox.Clear();
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
            ContentTextBox.Dispatcher.BeginInvoke(new Action(delegate()
            {
                string newText = Encoding.ASCII.GetString(buffer, 0, bytesToRead);

                // Analysis of apg01-05C7-00-000000-0000-00-008E-0000-0000

                ContentTextBox.Text += newText;
                // ContentTextBox.Text += "\n";
                ContentTextBox.ScrollToEnd();
                ContentScrollViewer.ScrollToVerticalOffset(ContentScrollViewer.ScrollableHeight);
                ContentScrollViewer.UpdateLayout();
            }));
        }

        private InputHistory GetInputHistory(TextBox textBox)
        {
            if (textBox.Equals(SendTextBox1))
            {
                return inputHistories[0]; 
            }
            else if (textBox.Equals(SendTextBox2))
            {
                return inputHistories[1];
            }
            else if (textBox.Equals(SendTextBox3))
            {
                return inputHistories[2];
            }
            else if (textBox.Equals(SendTextBox4))
            {
                return inputHistories[3];
            }
            else if (textBox.Equals(SendTextBox5))
            {
                return inputHistories[4];
            }
            else if (textBox.Equals(SendTextBox6))
            {
                return inputHistories[5];
            }
            else if (textBox.Equals(SendTextBox7))
            {
                return inputHistories[6];
            }
            else if (textBox.Equals(SendTextBox8))
            {
                return inputHistories[7];
            }
            else if (textBox.Equals(SendTextBox9))
            {
                return inputHistories[8];
            }
            else if (textBox.Equals(SendTextBox10))
            {
                return inputHistories[9];
            }
            return null;
        }

        private void SendTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            InputHistory inputHistory = GetInputHistory(textBox);
            string text = textBox.Text;
            char key = (char)KeyInterop.VirtualKeyFromKey(e.Key);
            if (e.Key == Key.Return)
            {
                SendText(text);
                inputHistory.AddEntry(text);
            }
            else if (e.Key == Key.Down)
            {
                InputHistoryItem item = inputHistory.FindPreviousHistoryItem();
                if (item != null)
                {
                    textBox.Text = item.Text;
                }
            }
            else if (e.Key == Key.Up)
            {
                InputHistoryItem item = inputHistory.FindNextHistoryItem();
                if (item != null)
                {
                    textBox.Text = item.Text;
                }
            }
            else if (e.Key >= Key.A && e.Key <= Key.Divide)
            {
                string completion = inputHistory.GetMostCloseTo(text);
                if (completion != null)
                {
                    e.Handled = true;
                    textBox.Text = completion;
                    textBox.SelectionStart = text.Length;
                    textBox.SelectionLength = completion.Length - textBox.SelectionLength;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPortNames();
        }

        // forward

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            int value = (int) ForwardSlider.Value;
            string hexValue = ComDataUtils.format(value, 4);
            string command = "Mf" + hexValue;
            SendText(command);
        }

        private void ForwardSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ForwardLabel == null)
            {
                return;
            }
            ForwardLabel.Content = ForwardSlider.Value + " mm";
        }

        // backward

        private void BackwardButton_Click(object sender, RoutedEventArgs e)
        {
            int value = (int)BackwardSlider.Value;
            string hexValue = ComDataUtils.format(value, 4);
            string command = "Mb" + hexValue;
            SendText(command);
        }

        private void BackwardSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BackwardLabel == null)
            {
                return;
            }
            BackwardLabel.Content = BackwardSlider.Value + " mm";
        }

        // left

        private void LeftSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (LeftLabel == null)
            {
                return;
            }
            LeftLabel.Content = LeftSlider.Value/10 + " °";
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            int value = (int)LeftSlider.Value;
            string hexValue = ComDataUtils.format(value, 4);
            string command = "Ml" + hexValue;
            SendText(command);
        }

        // Right

        private void RightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (RightLabel == null)
            {
                return;
            }
            RightLabel.Content = RightSlider.Value / 10 + " °";
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            int value = (int)RightSlider.Value;
            string hexValue = ComDataUtils.format(value, 4);
            string command = "Mr" + hexValue;
            SendText(command);
        }

    }
}
