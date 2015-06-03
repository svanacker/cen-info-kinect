using System.Windows;
using System.Windows.Controls;

namespace Org.Cen.RobotManager.Controls.Timer
{
    using Bindings;
    using Devices.Servo.Com;
    using Devices.Timer.Com;

    /// <summary>
    /// Interaction logic for TimerControl.xaml
    /// </summary>
    public partial class TimerControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public TimerControl()
        {
            InitializeComponent();
        }

        private void TimerReadAll_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            TimerReadCountOutData readCountOutData = new TimerReadCountOutData();
            string readCountMessage = readCountOutData.GetMessage();
            Main.SendText(readCountMessage);

            TimerReadCountInDataDecoder readCountDecoder = new TimerReadCountInDataDecoder();
            while (Main.receivedData.Length < readCountDecoder.GetDataLength(null))
            {
            }
            TimerReadCountInData readCountInData = (TimerReadCountInData)readCountDecoder.Decode(Main.receivedData.ToString());

            int count = readCountInData.Count;

            TimerDataGrid.Items.Clear();

            Main.receivedData.Clear();
            for (int timerIndex = 0; timerIndex < count; timerIndex++)
            { 
                TimerReadOutData readOutData = new TimerReadOutData(timerIndex );
                string readMessage = readOutData.GetMessage();
                Main.SendText(readMessage);

                TimerReadInDataDecoder readDecoder = new TimerReadInDataDecoder();
                while (Main.receivedData.Length < readDecoder.GetDataLength(null))
                {
                }
                TimerReadInData readInData = (TimerReadInData)readDecoder.Decode(Main.receivedData.ToString());

                TimerDataItem item = new TimerDataItem();
                item.Index = readInData.Index;
                item.Code = readInData.Code;
                item.Diviser = readInData.Diviser;
                item.InternalCounter = readInData.InternalCounter;
                item.Time = readInData.Time;
                item.MarkTime = readInData.MarkTime;
                item.Enabled = readInData.Enabled;

                TimerDataGrid.Items.Add(item);
            }

            TimerDataGrid.UpdateLayout();
        }

        public void UpdateTimerDetail()
        {
            TimerDataItem item = (TimerDataItem)TimerDataGrid.SelectedItem;
            bool selected = item != null;
            bool timerMarkValueNotEmpty = TimerMarkValueTextBox.Text.Length > 0;
            TimerEnabledCheckBox.IsEnabled = selected;
            TimerMarkButton.IsEnabled = selected;
            TimerCheckMarkButton.IsEnabled = selected && timerMarkValueNotEmpty;
            TimerMarkValueTextBox.IsEnabled = selected;

            if (selected)
            {
                TimerCodeValueLabel.Content = item.Code;
                TimerEnabledCheckBox.IsChecked = item.Enabled;
            }
            else
            {
                TimerCodeValueLabel.Content = "-";
            }
        }

        private void TimerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTimerDetail();
        }

        private void WriteTimerEnabled()
        {
            TimerDataItem item = (TimerDataItem)TimerDataGrid.SelectedItem;
            if (item == null)
            {
                return;
            }
            int timerIndex = item.Index;
            bool timerEnabled = TimerEnabledCheckBox.IsChecked != null && TimerEnabledCheckBox.IsChecked.Value;
            TimerWriteEnableOutData outData = new TimerWriteEnableOutData(timerIndex, timerEnabled);
            string message = outData.GetMessage();
            Main.SendText(message);

            item.Enabled = timerEnabled;
            TimerDataGrid.UpdateLayout();
        }

        private void TimerEnabledCheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            WriteTimerEnabled();
        }

        private void TimerEnabledCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            WriteTimerEnabled();
        }

        private void TimerMarkButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();

            TimerDataItem item = (TimerDataItem)TimerDataGrid.SelectedItem;
            if (item == null)
            {
                return;
            }
            int timerIndex = item.Index;
            TimerWriteMarkOutData writeOutData = new TimerWriteMarkOutData(timerIndex);
            string message = writeOutData.GetMessage();
            Main.SendText(message);


            TimerWriteMarkInDataDecoder readDecoder = new TimerWriteMarkInDataDecoder();
            while (Main.receivedData.Length < readDecoder.GetDataLength(null))
            {
            }
            TimerWriteMarkInData inData = (TimerWriteMarkInData)readDecoder.Decode(Main.receivedData.ToString());

            item.MarkTime = inData.TimerMark;
            TimerDataGrid.UpdateLayout();
        }

        private void TimerCheckMarkButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();

            TimerDataItem item = (TimerDataItem)TimerDataGrid.SelectedItem;
            if (item == null)
            {
                return;
            }
            int timerIndex = item.Index;
            int timerValue = int.Parse(TimerMarkValueTextBox.Text);
            TimerReadIsTimeoutOutData writeOutData = new TimerReadIsTimeoutOutData(timerIndex, timerValue);
            string message = writeOutData.GetMessage();
            Main.SendText(message);

            TimerReadIsTimeoutInDataDecoder decoder = new TimerReadIsTimeoutInDataDecoder();
            while (Main.receivedData.Length < decoder.GetDataLength(null))
            {
            }
            TimerReadIsTimeoutInData readInData = (TimerReadIsTimeoutInData)decoder.Decode(Main.receivedData.ToString());

            bool isTimeOut = readInData.TimeOut;

            TimeoutLabel.Content = isTimeOut.ToString();
        }

        private void TimerMarkValueTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTimerDetail();
        }
    }
}
