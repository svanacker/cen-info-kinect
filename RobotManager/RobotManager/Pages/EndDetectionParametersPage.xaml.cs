namespace Org.Cen.RobotManager.Pages
{
    using Devices.Pid;
    using Devices.Pid.Com;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for EndDetectionParametersControl.xaml
    /// </summary>
    public partial class EndDetectionParametersControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public EndDetectionParametersControl()
        {
            InitializeComponent();
        }


        private void EndMotionParameterReadButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            Main.SendText("pP");

            MotionEndDetectionParameterReadInDataDecoder decoder = new MotionEndDetectionParameterReadInDataDecoder();

            while (Main.receivedData.Length < decoder.GetDataLength(MotionEndDetectionParameterReadInData.HEADER))
            {

            }
            MotionEndDetectionParameterReadInData inData = (MotionEndDetectionParameterReadInData)decoder.Decode(Main.receivedData.ToString());
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

            MotionEndDetectionParameterWriteOutData outData = new MotionEndDetectionParameterWriteOutData(parameter);

            string data = outData.GetHeader() + outData.GetArguments();
            Main.SendText(data);
        }
    }
}
