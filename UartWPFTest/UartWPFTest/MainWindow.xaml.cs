
namespace UartWPFTest
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using System.IO.Ports;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using Org.Cen.Com.Utils;
    using Org.Cen.Devices.Eeprom.Com;
    using Org.Cen.Devices.Motion.Position;
    using Org.Cen.Devices.Motion.Position.Com;
    using Org.Cen.Devices.Pid;
    using Org.Cen.Devices.Pid.Com;
    using Org.Cen.Devices.Robot;
    using Org.Cen.Devices.Robot.Configuration.Com;
    using Org.Cen.Devices.Robot.Start.Com;
    using Org.Com.Devices.Motion.Position;
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    using LineSeries = OxyPlot.Series.LineSeries;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SerialPort currentPort;

        private const int COM_INPUT_COUNT = 10;

        private StringBuilder receivedData = new StringBuilder();

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

            string newText = Encoding.ASCII.GetString(buffer, 0, bytesToRead);

            receivedData.Append(newText);

            // Update the contentText
            ContentTextBox.Dispatcher.BeginInvoke(new Action(delegate()
            {
                // Analysis of apg01-05C7-00-000000-0000-00-008E-0000-0000

                ContentTextBox.Text += newText;
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
            int value = (int)ForwardSlider.Value;
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
            ForwardLabel.Content = (int)ForwardSlider.Value + " mm";
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
            BackwardLabel.Content = (int)BackwardSlider.Value + " mm";
        }

        // left

        private void LeftSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (LeftLabel == null)
            {
                return;
            }
            LeftLabel.Content = (int)LeftSlider.Value / 10 + " °";
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
            RightLabel.Content = (int)RightSlider.Value / 10 + " °";
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            int value = (int)RightSlider.Value;
            string hexValue = ComDataUtils.format(value, 4);
            string command = "Mr" + hexValue;
            SendText(command);
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            SendText("Mc");
        }

        // Go

        private void MotorGoButton_Click(object sender, RoutedEventArgs e)
        {
            int leftValue = (int)MotorLeftSlider.Value;
            string hexLeftValue = ComDataUtils.format(leftValue, 2);
            int rightValue = (int)MotorLeftSlider.Value;
            string hexRightValue = ComDataUtils.format(rightValue, 2);
            string command = "mw" + hexLeftValue + hexRightValue;
            SendText(command);
        }


        private void MotorStopButton_Click(object sender, RoutedEventArgs e)
        {
            receivedData.Clear();
            SendText("mc");

            while (receivedData.Length < 3)
            {
            }
            LeftLabel.Content = receivedData.ToString();

            receivedData.Clear();
        }

        private void MotorLeftSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (LeftValueLabel == null)
            {
                return;
            }
            LeftValueLabel.Content = (int)MotorLeftSlider.Value;
            if (SynchronizeMotorCheckBox.IsChecked.GetValueOrDefault(false))
            {
                RightValueLabel.Content = LeftValueLabel.Content;
            }
        }

        private void MotorRightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (RightValueLabel == null)
            {
                return;
            }
            RightValueLabel.Content = (int)MotorRightSlider.Value;
            if (SynchronizeMotorCheckBox.IsChecked.GetValueOrDefault(false))
            {
                LeftValueLabel.Content = RightValueLabel.Content;
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            ForwardSlider_ValueChanged(null, null);
            LeftSlider_ValueChanged(null, null);
            RightSlider_ValueChanged(null, null);
            BackwardSlider_ValueChanged(null, null);

            MotorLeftSlider_ValueChanged(null, null);
            MotorRightSlider_ValueChanged(null, null);
        }

        private void PIDGraph_Initialized(object sender, EventArgs e)
        {
            PlotModel pidModel = new PlotModel
            {
                Title = "PID Analyis",
            };
            PIDGraph.Model = pidModel;
        }

        private void MotionGraph_Initialized(object sender, EventArgs e)
        {
            PlotModel motionModel = new PlotModel
            {
                Title = "Motion Analyis",
            };
            MotionGraph.Model = motionModel;
        }

        private void LaunchAnalysisButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == LaunchAnalysisBackwardButton)
            {
                BackwardButton_Click(null, null);
            }
            else
            {
                ForwardButton_Click(null, null);
            }
            PlotModel pidModel = InitPIDGraphModel();
            PlotModel motionModel = InitMotionGraphModel();
            MotionDataGrid.Items.Clear();

            Thread.Sleep(100);

            float previousPosition = 0;
            float previousPidTime = 0;
            float previousNormalPosition = 0;
            for (int i = 0; i < 40; i++)
            {
                receivedData.Clear();
                SendText("pg00");

                PIDDebugDataDecoder decoder = new PIDDebugDataDecoder();

                while (receivedData.Length < decoder.GetDataLength(PIDDebugInData.HEADER))
                {

                }
                PIDDebugInData inData = (PIDDebugInData)decoder.Decode(receivedData.ToString());

                PIDDebugData debugData = inData.PIDDebugData;
                float pidTime = debugData.PidTime;
                float position = debugData.Position;
                float normalPosition = debugData.NormalPosition;
                float u = debugData.U;
                float error = debugData.Error;
                float speed = 0;
                float normalSpeed = 0;

                if (previousPidTime > 0)
                {
                    speed = (position - previousPosition) / (pidTime - previousPidTime);
                    normalSpeed = (normalPosition - previousNormalPosition) / (pidTime - previousPidTime);
                }

                // Graph PID
                LineSeries uSeries = (LineSeries)pidModel.Series[0];
                uSeries.Points.Add(new DataPoint(pidTime, u));
                LineSeries errorSeries = (LineSeries)pidModel.Series[1];
                errorSeries.Points.Add(new DataPoint(pidTime, error));

                // Position PID
                LineSeries positionSeries = (LineSeries)motionModel.Series[0];
                positionSeries.Points.Add(new DataPoint(pidTime, position));

                LineSeries normalPositionSeries = (LineSeries)motionModel.Series[1];
                normalPositionSeries.Points.Add(new DataPoint(pidTime, normalPosition));

                LineSeries speedSeries = (LineSeries)motionModel.Series[2];
                speedSeries.Points.Add(new DataPoint(pidTime, speed));

                LineSeries normalSpeedSeries = (LineSeries)motionModel.Series[3];
                normalSpeedSeries.Points.Add(new DataPoint(pidTime, normalSpeed));

                receivedData.Clear();

                previousPidTime = pidTime;
                previousPosition = position;
                previousNormalPosition = normalPosition;
                Thread.Sleep(40);

                MotionDataItem dataItem = new MotionDataItem();
                dataItem.PidTime = (int) pidTime;
                dataItem.NormalPosition = (int) normalPosition;
                dataItem.NormalSpeed = (int) normalSpeed;
                dataItem.Position = (int) position;
                dataItem.Speed = (int) speed;
                MotionDataGrid.Items.Add(dataItem);
            }
            pidModel.InvalidatePlot(true);
            motionModel.InvalidatePlot(true);
            MotionDataGrid.UpdateLayout();
        }

        public PlotModel InitPIDGraphModel()
        {
            PlotModel plotModel = PIDGraph.Model;

            plotModel.Axes.Clear();

            var leftAxis = new LinearAxis();
            leftAxis.Position = AxisPosition.Left;
            leftAxis.Key = "leftAxis";
            plotModel.Axes.Add(leftAxis);

            var rightAxis = new LinearAxis();
            rightAxis.Position = AxisPosition.Right;
            rightAxis.Key = "rightAxis";
            plotModel.Axes.Add(rightAxis);

            plotModel.Series.Clear();

            LineSeries uLineSeries = new LineSeries();
            uLineSeries.Title = "U";
            plotModel.Series.Add(uLineSeries);
            uLineSeries.YAxisKey = "leftAxis";
            leftAxis.AxislineColor = uLineSeries.Color;

            LineSeries errorSeries = new LineSeries();
            errorSeries.Title = "Error";
            plotModel.Series.Add(errorSeries);
            errorSeries.YAxisKey = "rightAxis";
            rightAxis.AxislineColor = errorSeries.Color;

            return plotModel;
        }

        public PlotModel InitMotionGraphModel()
        {
            PlotModel plotModel = MotionGraph.Model;

            plotModel.Axes.Clear();

            var leftAxis = new LinearAxis();
            leftAxis.Position = AxisPosition.Left;
            leftAxis.Key = "leftAxis";
            plotModel.Axes.Add(leftAxis);

            var rightAxis = new LinearAxis();
            rightAxis.Position = AxisPosition.Right;
            rightAxis.Key = "rightAxis";
            plotModel.Axes.Add(rightAxis);

            plotModel.Series.Clear();

            LineSeries positionSeries = new LineSeries();
            positionSeries.Title = "Position";
            plotModel.Series.Add(positionSeries);
            positionSeries.YAxisKey = "leftAxis";

            LineSeries normalPositionSeries = new LineSeries();
            normalPositionSeries.Title = "Normal Position";
            plotModel.Series.Add(normalPositionSeries);
            normalPositionSeries.YAxisKey = "leftAxis";

            LineSeries speedSeries = new LineSeries();
            speedSeries.Title = "Speed";
            plotModel.Series.Add(speedSeries);
            speedSeries.YAxisKey = "rightAxis";

            LineSeries normalSpeedSeries = new LineSeries();
            normalSpeedSeries.Title = "Normal Speed";
            plotModel.Series.Add(normalSpeedSeries);
            normalSpeedSeries.YAxisKey = "rightAxis";

            LineSeries profileSeries = new LineSeries();
            profileSeries.Title = "Profile Trajectory";
            plotModel.Series.Add(profileSeries);
            profileSeries.YAxisKey = "rightAxis";

            return plotModel;
        }

        private void ReadMotionParameterButton_Click(object sender, RoutedEventArgs e)
        {
            receivedData.Clear();
            SendText("pm00");

            ReadMotionParameterDataDecoder decoder = new ReadMotionParameterDataDecoder();

            while (receivedData.Length < decoder.GetDataLength(ReadMotionParameterInData.HEADER))
            {

            }
            ReadMotionParameterInData inData = (ReadMotionParameterInData)decoder.Decode(receivedData.ToString());

            MotionParameterData motionParameterData = inData.MotionParameterData;
            ThetaAccelerationLabel.Content = motionParameterData.Acceleration;
            ThetaSpeedLabel.Content = motionParameterData.Speed;
            ThetaSpeedMaxLabel.Content = motionParameterData.SpeedMax;
            ThetaTime1Label.Content = motionParameterData.Time1;
            ThetaTime2Label.Content = motionParameterData.Time2;
            ThetaTime3Label.Content = motionParameterData.Time3;
            ThetaPosition1Label.Content = motionParameterData.Position1;
            ThetaPosition2Label.Content = motionParameterData.Position2;

            // Draw graph
            PlotModel motionModel = MotionGraph.Model;
            LineSeries profileSeries = (LineSeries)motionModel.Series[4];

            // Draw Trapeze
            profileSeries.Points.Add(new DataPoint(0, 0));
            profileSeries.Points.Add(new DataPoint(motionParameterData.Time1, motionParameterData.SpeedMax));
            profileSeries.Points.Add(new DataPoint(motionParameterData.Time2, motionParameterData.SpeedMax));
            profileSeries.Points.Add(new DataPoint(motionParameterData.Time3, 0));

            motionModel.InvalidatePlot(true);

            // ALPHA

            receivedData.Clear();
            SendText("pm01");

            while (receivedData.Length < decoder.GetDataLength(ReadMotionParameterInData.HEADER))
            {

            }
            inData = (ReadMotionParameterInData)decoder.Decode(receivedData.ToString());
            motionParameterData = inData.MotionParameterData;
            AlphaAccelerationLabel.Content = motionParameterData.Acceleration;
            AlphaSpeedLabel.Content = motionParameterData.Speed;
            AlphaSpeedMaxLabel.Content = motionParameterData.SpeedMax;
            AlphaTime1Label.Content = motionParameterData.Time1;
            AlphaTime2Label.Content = motionParameterData.Time2;
            AlphaTime3Label.Content = motionParameterData.Time3;
            AlphaPosition1Label.Content = motionParameterData.Position1;
            AlphaPosition2Label.Content = motionParameterData.Position2;

        }

        private void EndMotionParameterReadButton_Click(object sender, RoutedEventArgs e)
        {
            receivedData.Clear();
            SendText("pP");

            ReadMotionEndDetectionParameterDataDecoder decoder = new ReadMotionEndDetectionParameterDataDecoder();

            while (receivedData.Length < decoder.GetDataLength(ReadMotionEndDetectionParameterInData.HEADER))
            {

            }
            ReadMotionEndDetectionParameterInData inData = (ReadMotionEndDetectionParameterInData)decoder.Decode(receivedData.ToString());
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
            parameter.AbsDeltaPositionIntegralFactorThreshold = (float) AbsDeltaPositionIntegralFactorThresholdSlider.Value; 
            parameter.MaxUIntegralFactorThreshold = (float) MaxUIntegralFactorThresholdSlider.Value;
            parameter.MaxUIntegralConstantThreshold = (float) MaxUIntegralConstantThresholdSlider.Value;
            parameter.TimeRangeAnalysis = (int) TimeRangeAnalysisSlider.Value;
            parameter.NoAnalysisAtStartupTime = (int) NoAnalysisAtStartupTimeSlider.Value;

            WriteMotionEndDetectionParameterOutData outData = new WriteMotionEndDetectionParameterOutData(parameter);

            string data = outData.getHeader() + outData.getArguments();
            SendText(data);
        }

        private void ClearPositionButton_Click(object sender, RoutedEventArgs e)
        {
            receivedData.Clear();
            SendText("wc");
            Thread.Sleep(100);
            ReadPositionButton_Click(null, null);
        }

        private void ReadPositionButton_Click(object sender, RoutedEventArgs e)
        {
            receivedData.Clear();
            SendText("wr");
            WheelPositionDataDecoder decoder = new WheelPositionDataDecoder();

            while (receivedData.Length < decoder.GetDataLength(ReadWheelPositionInData.HEADER))
            {

            }
            ReadWheelPositionInData inData = (ReadWheelPositionInData)decoder.Decode(receivedData.ToString());
            WheelPositionData wheelPositionData = inData.WheelPosition;
            LeftPositionValueLabel.Content = wheelPositionData.LeftPosition;
            RightPositionValueLabel.Content = wheelPositionData.RightPosition;
        }

        private void ReadRobotPositionButton_Click(object sender, RoutedEventArgs e)
        {
            receivedData.Clear();
            SendText("nr");
            ReadRobotPositionDataDecoder decoder = new ReadRobotPositionDataDecoder();

            while (receivedData.Length < decoder.GetDataLength(ReadRobotPositionInData.HEADER))
            {

            }
            ReadRobotPositionInData inData = (ReadRobotPositionInData)decoder.Decode(receivedData.ToString());
            RobotPosition robotPosition = inData.Position;

            XTextBox.Text = robotPosition.X.ToString();
            YTextBox.Text = robotPosition.Y.ToString();
            AngleTextBox.Text = robotPosition.DeciDegreeAngle.ToString();
        
            UpdateCanvasRobotPosition(robotPosition);
        }

        public void UpdateCanvasRobotPosition(RobotPosition robotPosition)
        {
            RobotPositionTranslateTransform.X = robotPosition.X / 10.0d;
            RobotPositionTranslateTransform.Y = robotPosition.Y / 10.0d;
            RobotPositionRotateTransform.Angle = robotPosition.DeciDegreeAngle / 10.0d;
        }

        private void WriteRobotPositionButton_Click(object sender, RoutedEventArgs e)
        {
            RobotPosition robotPosition = new RobotPosition();
            robotPosition.X = int.Parse(XTextBox.Text);
            robotPosition.Y = int.Parse(YTextBox.Text);
            robotPosition.DeciDegreeAngle = int.Parse(AngleTextBox.Text);

            WriteRobotPositionOutData outData = new WriteRobotPositionOutData(robotPosition);
            SendText(outData.getMessage());

            UpdateCanvasRobotPosition(robotPosition);
        }

        private void PositionTabItem_SizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        private void PositionGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GameBoardScaleTransform.ScaleX = PositionGrid.RenderSize.Height / 300;
            GameBoardScaleTransform.ScaleY = -PositionGrid.RenderSize.Height / 300;
            GameBoardScaleTranslateTransform.Y = PositionGrid.RenderSize.Height;
            GameBoardCanvas.UpdateLayout();
        }

        public void UpdatePaths()
        {
            foreach (Path path in FindVisualChildren<Path>(Main_Window))
            {
                if (path.Equals(Robot))
                {
                    continue;
                }
                if (ShowPathCheckBox.IsChecked != null && ShowPathCheckBox.IsChecked.Value == true)
                {
                    path.Visibility = Visibility.Visible;
                }
                else
                {
                    path.Visibility = Visibility.Hidden;
                }
                if (PathStrokedBoxCheckBox.IsChecked != null && PathStrokedBoxCheckBox.IsChecked.Value == true)
                {
                    path.StrokeThickness = 35;
                }
                else
                {
                    path.StrokeThickness = 1;
                }
            }
        }

        private void ShowPathCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdatePaths();
        }

        private void EnableRobotStrockeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdatePaths();
        }

        private void ShowRobotCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (ShowRobotCheckBox.IsChecked == true)
            {
                Robot.Visibility = Visibility.Visible;
            }
            else
            {
                Robot.Visibility = Visibility.Hidden;
            }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void ConfigReadButton_Click(object sender, RoutedEventArgs e)
        {
            receivedData.Clear();
            RobotConfigReadOutData outData = new RobotConfigReadOutData();
            string message = outData.getMessage();
            SendText(message);

            RobotConfigReadInDataDecoder decoder = new RobotConfigReadInDataDecoder();

            while (receivedData.Length < decoder.GetDataLength(RobotConfigReadInData.HEADER))
            {

            }
            RobotConfigReadInData inData = (RobotConfigReadInData)decoder.Decode(receivedData.ToString());
            RobotConfig config = inData.Config;

            ConfigStrategyIndexSlider.Value = config.StrategyIndex;
            ConfigDontWaitForStartCheckBox.IsChecked = config.DontWaitForStart;
            ConfigDontEndForStartCheckBox.IsChecked = config.DoNotEnd;
            ConfigDontCheckOpponentStartCheckBox.IsChecked = config.DontUseBeacon;
            ConfigRollingTestCheckBox.IsChecked = config.RollingTest;
            ConfigGreenCheckBox.IsChecked = config.UseGreen;
            ConfigLowCheckBox.IsChecked = config.SpeedLow;
            ConfigVeryLowCheckBox.IsChecked = config.SpeedVeryLow;
            ConfigUltraLowCheckBox.IsChecked = config.SpeedUltraLow;
        }

        private void ConfigWriteButton_Click(object sender, RoutedEventArgs e)
        {
            receivedData.Clear();
            RobotConfig robotConfig = new RobotConfig(0);
            robotConfig.StrategyIndex = (int)ConfigStrategyIndexSlider.Value;
            robotConfig.DontWaitForStart = ConfigDontWaitForStartCheckBox.IsChecked != null &&
                                           ConfigDontWaitForStartCheckBox.IsChecked.Value;
            robotConfig.DoNotEnd = ConfigDontEndForStartCheckBox.IsChecked != null &&
                                           ConfigDontEndForStartCheckBox.IsChecked.Value;
            robotConfig.DontUseBeacon = ConfigDontCheckOpponentStartCheckBox.IsChecked != null &&
                                           ConfigDontCheckOpponentStartCheckBox.IsChecked.Value;
            robotConfig.RollingTest = ConfigRollingTestCheckBox.IsChecked != null &&
                                           ConfigRollingTestCheckBox.IsChecked.Value;
            robotConfig.UseGreen = ConfigGreenCheckBox.IsChecked != null &&
                                           ConfigGreenCheckBox.IsChecked.Value;
            robotConfig.SpeedLow = ConfigLowCheckBox.IsChecked != null &&
                                           ConfigLowCheckBox.IsChecked.Value;
            robotConfig.SpeedVeryLow = ConfigVeryLowCheckBox.IsChecked != null &&
                                           ConfigVeryLowCheckBox.IsChecked.Value;
            robotConfig.SpeedUltraLow = ConfigUltraLowCheckBox.IsChecked != null &&
                                           ConfigUltraLowCheckBox.IsChecked.Value;

            RobotConfigWriteOutData outData = new RobotConfigWriteOutData(robotConfig);
            string message = outData.getMessage();
            SendText(message);
        }

        private void StartParametersRead_Click(object sender, RoutedEventArgs e)
        {
            receivedData.Clear();

            // Yellow
            StartMatchReadPositionOutData outData = new StartMatchReadPositionOutData(MatchSide.Yellow);
            string message = outData.getMessage();
            SendText(message);

            StartMatchReadPositionInDataDecoder decoder = new StartMatchReadPositionInDataDecoder();

            while (receivedData.Length < decoder.GetDataLength(StartMatchReadPositionInData.HEADER))
            {

            }
            StartMatchReadPositionInData inData = (StartMatchReadPositionInData)decoder.Decode(receivedData.ToString());

            YellowX.Text = inData.X.ToString();
            YellowY.Text = inData.Y.ToString();
            YellowAngle.Text = inData.AngleDeciDegree.ToString();

            // Green
            receivedData.Clear();
            outData = new StartMatchReadPositionOutData(MatchSide.Green);
            message = outData.getMessage();
            SendText(message);

            decoder = new StartMatchReadPositionInDataDecoder();

            while (receivedData.Length < decoder.GetDataLength(StartMatchReadPositionInData.HEADER))
            {

            }
            inData = (StartMatchReadPositionInData)decoder.Decode(receivedData.ToString());

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
            SendText(outData.getMessage());

            // Green
            x = int.Parse(GreenX.Text);
            y = int.Parse(GreenY.Text);
            angle = int.Parse(GreenAngle.Text);
            outData = new StartMatchWritePositionOutData(MatchSide.Green, x, y, angle);
            SendText(outData.getMessage());
        }

        private void ShowUsageButton_Click(object sender, RoutedEventArgs e)
        {
            SendText("Su");
        }

        private void ClearTargetBufferButton_Click(object sender, RoutedEventArgs e)
        {
            SendText("z");
        }

        private void ReadEepromButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
