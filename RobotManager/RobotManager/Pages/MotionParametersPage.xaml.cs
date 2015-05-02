using System.Windows;
using System.Windows.Controls;

namespace Org.Cen.RobotManager.Pages
{
    using UartWPFTest;

    /// <summary>
    /// Interaction logic for MotionParameters.xaml
    /// </summary>
    public partial class MotionParametersPage : Page
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public MotionParametersPage()
        {
            InitializeComponent();
        }

        private void ReadMotionParameterButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO
            //Main.receivedData.Clear();
            //Main.SendText("pm00");

            //ReadMotionParameterDataDecoder decoder = new ReadMotionParameterDataDecoder();

            //while (Main.receivedData.Length < decoder.GetDataLength(ReadMotionParameterInData.HEADER))
            //{

            //}
            //ReadMotionParameterInData inData = (ReadMotionParameterInData)decoder.Decode(Main.receivedData.ToString());

            //MotionParameterData motionParameterData = inData.MotionParameterData;
            //ThetaAccelerationLabel.Content = motionParameterData.Acceleration;
            //ThetaSpeedLabel.Content = motionParameterData.Speed;
            //ThetaSpeedMaxLabel.Content = motionParameterData.SpeedMax;
            //ThetaTime1Label.Content = motionParameterData.Time1;
            //ThetaTime2Label.Content = motionParameterData.Time2;
            //ThetaTime3Label.Content = motionParameterData.Time3;
            //ThetaPosition1Label.Content = motionParameterData.Position1;
            //ThetaPosition2Label.Content = motionParameterData.Position2;

            //// Draw graph
            //PlotModel motionModel = Main.MotionGraph.Model;
            //LineSeries profileSeries = (LineSeries)motionModel.Series[4];

            //// Draw Trapeze
            //profileSeries.Points.Add(new DataPoint(0, 0));
            //profileSeries.Points.Add(new DataPoint(motionParameterData.Time1, motionParameterData.SpeedMax));
            //profileSeries.Points.Add(new DataPoint(motionParameterData.Time2, motionParameterData.SpeedMax));
            //profileSeries.Points.Add(new DataPoint(motionParameterData.Time3, 0));

            //motionModel.InvalidatePlot(true);

            //// ALPHA

            //Main.receivedData.Clear();
            //Main.SendText("pm01");

            //while (Main.receivedData.Length < decoder.GetDataLength(ReadMotionParameterInData.HEADER))
            //{

            //}
            //inData = (ReadMotionParameterInData)decoder.Decode(Main.receivedData.ToString());
            //motionParameterData = inData.MotionParameterData;
            //AlphaAccelerationLabel.Content = motionParameterData.Acceleration;
            //AlphaSpeedLabel.Content = motionParameterData.Speed;
            //AlphaSpeedMaxLabel.Content = motionParameterData.SpeedMax;
            //AlphaTime1Label.Content = motionParameterData.Time1;
            //AlphaTime2Label.Content = motionParameterData.Time2;
            //AlphaTime3Label.Content = motionParameterData.Time3;
            //AlphaPosition1Label.Content = motionParameterData.Position1;
            //AlphaPosition2Label.Content = motionParameterData.Position2;

        }

        private void MotionParametersGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Main.MotionParameters = this;
        }

    }
}
