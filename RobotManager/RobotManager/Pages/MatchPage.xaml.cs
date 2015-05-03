namespace Org.Cen.RobotManager.Pages
{
    using System.Windows;
    using System.Windows.Controls;

    using Devices.Robot;
    using Devices.Robot.End.Com;
    using Devices.Robot.Start.Com;
    using UartWPFTest;

    /// <summary>
    /// Interaction logic for MatchPage.xaml
    /// </summary>
    public partial class MatchPage : Page
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public MatchPage()
        {
            InitializeComponent();
        }


        private void StartParametersRead_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();

            // Yellow
            StartMatchReadPositionOutData outData = new StartMatchReadPositionOutData(MatchSide.Yellow);
            string message = outData.getMessage();
            Main.SendText(message);

            StartMatchReadPositionInDataDecoder decoder = new StartMatchReadPositionInDataDecoder();

            while (Main.receivedData.Length < decoder.GetDataLength(StartMatchReadPositionInData.HEADER))
            {

            }
            StartMatchReadPositionInData inData = (StartMatchReadPositionInData)decoder.Decode(Main.receivedData.ToString());

            YellowX.Text = inData.X.ToString();
            YellowY.Text = inData.Y.ToString();
            YellowAngle.Text = inData.AngleDeciDegree.ToString();

            // Green
            Main.receivedData.Clear();
            outData = new StartMatchReadPositionOutData(MatchSide.Green);
            message = outData.getMessage();
            Main.SendText(message);

            decoder = new StartMatchReadPositionInDataDecoder();

            while (Main.receivedData.Length < decoder.GetDataLength(StartMatchReadPositionInData.HEADER))
            {

            }
            inData = (StartMatchReadPositionInData)decoder.Decode(Main.receivedData.ToString());

            GreenX.Text = inData.X.ToString();
            GreenY.Text = inData.Y.ToString();
            GreenAngle.Text = inData.AngleDeciDegree.ToString();
        }

        private void StartParametersWrite_Click(object sender, RoutedEventArgs e)
        {
            // Yellow
            int x = int.Parse(YellowX.Text);
            int y = int.Parse(YellowY.Text);
            int angle = int.Parse(YellowAngle.Text);
            StartMatchWritePositionOutData outData = new StartMatchWritePositionOutData(MatchSide.Yellow, x, y, angle);
            Main.SendText(outData.getMessage());

            // Green
            x = int.Parse(GreenX.Text);
            y = int.Parse(GreenY.Text);
            angle = int.Parse(GreenAngle.Text);
            outData = new StartMatchWritePositionOutData(MatchSide.Green, x, y, angle);
            Main.SendText(outData.getMessage());
        }

        private void MatchGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Main.Match = this;
        }

        private void TimeLeftReadButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            EndMatchReadTimeLeftOutData outData = new EndMatchReadTimeLeftOutData();
            string message = outData.getMessage();
            Main.SendText(message);

            EndMatchReadTimeLeftInDataDecoder decoder = new EndMatchReadTimeLeftInDataDecoder();

            while (Main.receivedData.Length < decoder.GetDataLength(EndMatchReadTimeLeftInData.HEADER))
            {

            }
            EndMatchReadTimeLeftInData inData = (EndMatchReadTimeLeftInData)decoder.Decode(Main.receivedData.ToString());

            TimeLeftValueLabel.Content = inData.TimeLeft;
        }

        private void SimulateMatchStartButton_Click(object sender, RoutedEventArgs e)
        {
            StartMatchSetStartedOutData outData = new StartMatchSetStartedOutData(true);
            string message = outData.getMessage();
            Main.SendText(message);
        }
    }
}
