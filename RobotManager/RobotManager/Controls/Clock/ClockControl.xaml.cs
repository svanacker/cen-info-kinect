namespace Org.Cen.RobotManager.Controls.Clock
{
    using System.Windows;
    using System.Windows.Controls;

    using Devices.Clock.Com;

    /// <summary>
    /// Interaction logic for ClockControl.xaml
    /// </summary>
    public partial class ClockControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public ClockControl()
        {
            InitializeComponent();
        }



        private void ReadClock(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();

            ClockReadOutData outData = new ClockReadOutData();
            //Get header (no arguments here) to send
            string message = outData.GetMessage();
            //Send header "kr"
            Main.SendText(message);

            ClockReadInDataDecoder decoder = new ClockReadInDataDecoder();

            //Wait for receive all the data
            while (Main.receivedData.Length < decoder.GetDataLength(ClockReadInData.HEADER))
            {

            }
            //Decode data and stock it in inData.Clock
            ClockReadInData inData = (ClockReadInData)decoder.Decode(Main.receivedData.ToString());

            //Display data in HourLabel
            // HourLabel.Content = inData.Clock.Hour + ":" + inData.Clock.Minute + ":" + inData.Clock.Second + "   " +
            //                     inData.Clock.Day + "/" + inData.Clock.Month + "/" + inData.Clock.Year;

            WriteHourTextBoxClock.Text = inData.Clock.Hour.ToString();
            WriteMinuteTextBoxClock.Text = inData.Clock.Minute.ToString();
            WriteSecondTextBoxClock.Text = inData.Clock.Second.ToString();

            WriteDayTextBoxClock.Text = inData.Clock.Day.ToString();
            WriteMonthTextBoxClock.Text = inData.Clock.Month.ToString();
            WriteYearTextBoxClock.Text = inData.Clock.Year.ToString();
        }

        private void WriteClockHour(object sender, RoutedEventArgs e)
        {
            //Get value of TextBlock 
            int hour = int.Parse(WriteHourTextBoxClock.Text);
            int minute = int.Parse(WriteMinuteTextBoxClock.Text);
            int second = int.Parse(WriteSecondTextBoxClock.Text);

            //Use ClockWriteDateOutData class for use data as arguments
            ClockWriteDateOutData writeData = new ClockWriteDateOutData(hour, minute, second);
            //Send data
            Main.SendText(writeData.GetMessage());
        }

        private void WriteClockDate(object sender, RoutedEventArgs e)
        {
            //Same as WriteClockHour()
            int day = int.Parse(WriteDayTextBoxClock.Text);
            int month = int.Parse(WriteMonthTextBoxClock.Text);
            int year = int.Parse(WriteYearTextBoxClock.Text);

            ClockWriteDateOutData writeData = new ClockWriteDateOutData(day, month, year);
            Main.SendText(writeData.GetMessage());
        }
    }
}