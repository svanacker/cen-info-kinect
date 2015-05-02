using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Org.Cen.RobotManager.Pages
{
    using System.Threading;
    using Devices.Pid;
    using Devices.Pid.Com;
    using Graph;
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    using UartWPFTest;

    /// <summary>
    /// Interaction logic for MotionGraphPage.xaml
    /// </summary>
    public partial class MotionGraphPage : Page
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public MotionGraphPage()
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


        private void MotionGraphGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Main.MotionGraph = this;
        }
    }
}
