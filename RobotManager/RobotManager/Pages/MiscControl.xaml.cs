using Org.Cen.Devices.Clock;

namespace Org.Cen.RobotManager.Pages
{
    using System.Windows;
    using System.Windows.Controls;

    using Devices.Clock.Com;


    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class MiscControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public MiscControl()
        {
            InitializeComponent();
        }

        private void MiscGrid_Loaded(object sender, RoutedEventArgs e)
        {
            // Main.Misc = this;
        }

        private void ReadClock(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();

            ClockReadOutData outData = new ClockReadOutData();
            //Get header (no arguments here) to send
            string message = outData.getMessage();
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
            HourLabel.Content = inData.Clock.Hour + ":" + inData.Clock.Minute + ":" + inData.Clock.Second + "   " +
                                inData.Clock.Day + "/" + inData.Clock.Month + "/" + inData.Clock.Year;
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
            Main.SendText(writeData.getMessage());
        }

        private void WriteClockDate(object sender, RoutedEventArgs e)
        {
            //Same as WriteClockHour()
            int day = int.Parse(WriteDayTextBoxClock.Text);
            int month = int.Parse(WriteMonthTextBoxClock.Text);
            int year = int.Parse(WriteYearTextBoxClock.Text);

            ClockWriteDateOutData writeData = new ClockWriteDateOutData(day, month, year);
            Main.SendText(writeData.getMessage());
        }
    }
}
