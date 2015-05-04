namespace Org.Cen.RobotManager.Pages
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    using System.Threading;
    using Devices.Pid;
    using Devices.Pid.Com;
    using Graph;
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    using UartWPFTest;

    /// <summary>
    /// Interaction logic for PIDGraphControl.xaml
    /// </summary>
    public partial class PIDGraphControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public PIDGraphControl()
        {
            InitializeComponent();
        }


        private void PIDGraph_Initialized(object sender, EventArgs e)
        {
            PlotModel pidModel = new PlotModel
            {
                Title = "PID Analyis",
            };
            PIDGraph.Model = pidModel;
        }

        public PlotModel InitPidGraphModel()
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


        private void LaunchAnalysisButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (TabItem tabItem in Main.MainTabControl.Items)
            {
                Main.MainTabControl.SelectedItem = tabItem;
                Main.MainTabControl.UpdateLayout();
            }

            if (sender == Main.PIDGraph.LaunchAnalysisBackwardButton)
            {
                Main.Run.BackwardButton_Click(null, null);
            }
            else
            {
                Main.Run.ForwardButton_Click(null, null);
            }
            PlotModel pidModel = Main.PIDGraph.InitPidGraphModel();
            PlotModel motionModel = Main.MotionGraph.InitMotionGraphModel();
            Main.RawData.MotionDataGrid.Items.Clear();

            Thread.Sleep(100);

            float previousPosition = 0;
            float previousPidTime = 0;
            float previousNormalPosition = 0;
            for (int i = 0; i < 40; i++)
            {
                Main.receivedData.Clear();
                PidDebugOutData outData = new PidDebugOutData(InstructionType.Theta);
                string message = outData.getMessage();
                Main.SendText(message);

                PIDDebugDataDecoder decoder = new PIDDebugDataDecoder();

                while (Main.receivedData.Length < decoder.GetDataLength(PIDDebugInData.HEADER))
                {

                }
                PIDDebugInData inData = (PIDDebugInData)decoder.Decode(Main.receivedData.ToString());

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

                Main.receivedData.Clear();

                previousPidTime = pidTime;
                previousPosition = position;
                previousNormalPosition = normalPosition;
                Thread.Sleep(40);

                MotionDataItem dataItem = new MotionDataItem();
                dataItem.PidTime = (int)pidTime;
                dataItem.NormalPosition = (int)normalPosition;
                dataItem.NormalSpeed = (int)normalSpeed;
                dataItem.Position = (int)position;
                dataItem.Speed = (int)speed;
                Main.RawData.MotionDataGrid.Items.Add(dataItem);
            }
            pidModel.InvalidatePlot(true);
            motionModel.InvalidatePlot(true);
            Main.RawData.MotionDataGrid.UpdateLayout();
        }
    }
}
