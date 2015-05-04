
namespace Org.Cen.RobotManager.Pages
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    using UartWPFTest;

    /// <summary>
    /// Interaction logic for MotionGraphControl.xaml
    /// </summary>
    public partial class MotionGraphControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public MotionGraphControl()
        {
            InitializeComponent();
        }

        private void MotionGraph_Initialized(object sender, EventArgs e)
        {
            PlotModel motionModel = new PlotModel
            {
                Title = "Motion Analyis",
            };
            MotionGraph.Model = motionModel;
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
    }
}
