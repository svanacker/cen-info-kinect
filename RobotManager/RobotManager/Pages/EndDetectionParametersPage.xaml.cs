using System.Windows;
using System.Windows.Controls;

namespace Org.Cen.RobotManager.Pages
{
    using Devices.Pid;
    using Devices.Pid.Com;
    using UartWPFTest;

    /// <summary>
    /// Interaction logic for EndDetectionParametersPage.xaml
    /// </summary>
    public partial class EndDetectionParametersPage : Page
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public EndDetectionParametersPage()
        {
            InitializeComponent();
        }


        private void EndMotionParameterReadButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            Main.SendText("pP");

            ReadMotionEndDetectionParameterDataDecoder decoder = new ReadMotionEndDetectionParameterDataDecoder();

            while (Main.receivedData.Length < decoder.GetDataLength(ReadMotionEndDetectionParameterInData.HEADER))
            {

            }
            ReadMotionEndDetectionParameterInData inData = (ReadMotionEndDetectionParameterInData)decoder.Decode(Main.receivedData.ToString());
            MotionEndDetectionParameter parameter = inData.EndDetectionParameter;

            AbsDeltaPositionIntegralFactorThresholdSlider.Value = parameter.AbsDeltaPositionIntegralFactorThreshold;
            MaxUIntegralFactorThresholdSlider.Value = parameter.MaxUIntegralFactorThreshold;
            MaxUIntegralConstantThresholdSlider.Value = parameter.MaxUIntegralConstantThreshold;
            TimeRangeAnalysisSlider.Value = parameter.TimeRangeAnalysis;
            NoAnalysisAtStartupTimeSlider.Value = parameter.NoAnalysisAtStartupTime;
        }

        private void EndMotionParameterWriteButton_Click(object sender, RoutedEventArgs e)
        {
            MotionEndDetectionParameter parameter = new MotionEndDetectionParameter();
            parameter.AbsDeltaPositionIntegralFactorThreshold = (float)AbsDeltaPositionIntegralFactorThresholdSlider.Value;
            parameter.MaxUIntegralFactorThreshold = (float)MaxUIntegralFactorThresholdSlider.Value;
            parameter.MaxUIntegralConstantThreshold = (float)MaxUIntegralConstantThresholdSlider.Value;
            parameter.TimeRangeAnalysis = (int)TimeRangeAnalysisSlider.Value;
            parameter.NoAnalysisAtStartupTime = (int)NoAnalysisAtStartupTimeSlider.Value;

            WriteMotionEndDetectionParameterOutData outData = new WriteMotionEndDetectionParameterOutData(parameter);

            string data = outData.getHeader() + outData.getArguments();
            Main.SendText(data);
        }

        private void EndDetectionParametersGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Main.EndDetectionParameters = this;
        }

    }
}
