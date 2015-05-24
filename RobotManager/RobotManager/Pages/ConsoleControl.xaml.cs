using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Org.Cen.RobotManager.Pages
{
    using Controls;
    using Devices.System;
    using UartWPFTest;

    /// <summary>
    /// Interaction logic for ConsoleControl.xaml
    /// </summary>
    public partial class ConsoleControl : UserControl
    {
        private const int COM_INPUT_COUNT = 10;

        private InputHistory[] inputHistories = new InputHistory[COM_INPUT_COUNT];

        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public ConsoleControl()
        {
            InitializeComponent();
            for (int i = 0; i < COM_INPUT_COUNT; i++)
            {
                inputHistories[i] = new InputHistory();
            }
            
        }

        public void UpdateInDataText(string newText)
        {
            ContentTextBox.Dispatcher.BeginInvoke(new Action(delegate()
            {
                // Analysis of apg01-05C7-00-000000-0000-00-008E-0000-0000

                ContentTextBox.Text += newText;
                ContentTextBox.ScrollToEnd();
                ContentScrollViewer.ScrollToVerticalOffset(ContentScrollViewer.ScrollableHeight);
                ContentScrollViewer.UpdateLayout();
            }));
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


        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            if (senderButton == null)
            {
                return;
            }
            TextBox textBox = GetLinkedTextBox(senderButton);
            string text = textBox.Text;
            Main.SendText(text);
            InputHistory inputHistory = GetInputHistory(textBox);
            inputHistory.AddEntry(text);
        }

        private void SendTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            InputHistory inputHistory = GetInputHistory(textBox);
            string text = textBox.Text;
            char key = (char)KeyInterop.VirtualKeyFromKey(e.Key);
            if (e.Key == Key.Return)
            {
                Main.SendText(text);
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

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ContentTextBox.Clear();
        }

        private void ShowUsageButton_Click(object sender, RoutedEventArgs e)
        {
            SystemUsageOutData outData = new SystemUsageOutData();
            Main.SendText(outData.GetMessage());
        }

        private void ClearTargetBufferButton_Click(object sender, RoutedEventArgs e)
        {
            Main.SendText("z");
        }
    }
}
