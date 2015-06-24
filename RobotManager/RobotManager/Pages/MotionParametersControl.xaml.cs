
namespace Org.Cen.RobotManager.Pages
{
    using Devices.Motion.Pid.Com;
    using Devices.Pid;
    using Devices.Pid.Com;
    using OxyPlot;
    using OxyPlot.Series;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for MotionParameters.xaml
    /// </summary>
    public partial class MotionParametersControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public MotionParametersControl()
        {
            InitializeComponent();
        }

        private void ReadMotionParameterButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            Main.SendText("pm00");

            MotionParameterReadInDataDecoder decoder = new MotionParameterReadInDataDecoder();

            while (Main.receivedData.Length < decoder.GetDataLength(MotionParameterReadInData.HEADER))
            {

            }
            MotionParameterReadInData inData = (MotionParameterReadInData)decoder.Decode(Main.receivedData.ToString());

            MotionParameterData motionParameterData = inData.MotionParameterData;
            ThetaAccelerationLabel.Content = motionParameterData.Acceleration;
            ThetaSpeedLabel.Content = motionParameterData.Speed;
            ThetaSpeedMaxLabel.Content = motionParameterData.SpeedMax;
            ThetaTime1Label.Content = motionParameterData.Time1;
            ThetaTime2Label.Content = motionParameterData.Time2;
            ThetaTime3Label.Content = motionParameterData.Time3;
            ThetaPosition1Label.Content = motionParameterData.Position1;
            ThetaPosition2Label.Content = motionParameterData.Position2;
            ThetaNextPositionLabel.Content = motionParameterData.NextPosition;

            // Draw graph
            PlotModel motionModel = Main.MotionGraph.MotionGraph.Model;
            LineSeries profileSeries = (LineSeries)motionModel.Series[4];

            // Draw Trapeze
            profileSeries.Points.Add(new DataPoint(0, 0));
            profileSeries.Points.Add(new DataPoint(motionParameterData.Time1, motionParameterData.SpeedMax));
            profileSeries.Points.Add(new DataPoint(motionParameterData.Time2, motionParameterData.SpeedMax));
            profileSeries.Points.Add(new DataPoint(motionParameterData.Time3, 0));

            motionModel.InvalidatePlot(true);

            // ALPHA

            Main.receivedData.Clear();
            Main.SendText("pm01");

            while (Main.receivedData.Length < decoder.GetDataLength(MotionParameterReadInData.HEADER))
            {

            }
            inData = (MotionParameterReadInData)decoder.Decode(Main.receivedData.ToString());
            motionParameterData = inData.MotionParameterData;
            AlphaAccelerationLabel.Content = motionParameterData.Acceleration;
            AlphaSpeedLabel.Content = motionParameterData.Speed;
            AlphaSpeedMaxLabel.Content = motionParameterData.SpeedMax;
            AlphaTime1Label.Content = motionParameterData.Time1;
            AlphaTime2Label.Content = motionParameterData.Time2;
            AlphaTime3Label.Content = motionParameterData.Time3;
            AlphaPosition1Label.Content = motionParameterData.Position1;
            AlphaPosition2Label.Content = motionParameterData.Position2;
            AlphaNextPositionLabel.Content = motionParameterData.NextPosition;
        }
    }
}
