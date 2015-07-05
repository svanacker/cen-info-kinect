using System.Windows.Controls;

namespace Org.Cen.RobotManager.Pages
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using Devices.Navigation;
    using Devices.Navigation.Com;

    public class Navigator
    {
        private List<Point> points = new List<Point>();

        public Navigator(double x, double y)
        {
            this.points.Add(new Point(x, y));
        }

        public void NavigateTo(double x, double y)
        {
            this.points.Add(new Point(x, y));
        }

        public Tuple<string, Point[]> Stroke()
        {
            string path = this.points.Select(t => t.ToString()).Aggregate((f, s) => "L" + f + " L" + s);
            path = "M" + path.Substring(2, path.Length - 2);

            Tuple<string, Point[]> stroke = new Tuple<string, Point[]>(path, this.points.ToArray());
            points.Clear();

            return stroke;
        }
    }

    /// <summary>
    /// Interaction logic for NavigationControl.xaml
    /// </summary>
    /// 
    /// 
    public partial class NavigationControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public NavigationControl()
        {
            InitializeComponent();
        }

        private void LocationClearButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            NavigationLocationListClearOutData outData = new NavigationLocationListClearOutData();
            string message = outData.GetMessage();
            Main.SendText(message);
        }

        private void GetPathList(FrameworkContentElement control, IList pathControls)
        {
            /*
            IEnumerable children = LogicalTreeHelper.GetChildren(control);
            foreach (FrameworkContentElement childControl in children)
            {
                if (childControl is Path)
                {
                    pathControls.Add(childControl);
                }
                GetPathList(childControl, pathControls);
            }
            */
        }

        private void LocationCopyCanvasButton_Click(object sender, RoutedEventArgs e)
        {
            UIElementCollection elementCollection = GameBoard.GameBoardCanvas.Children;
            foreach (UIElement element in elementCollection)
            {
                if (!(element is Path))
                {
                    continue;
                }
                Path elementPath = (Path) element;
                if (!(elementPath.Data is StreamGeometry))
                {
                    continue;
                }
                /*
                StreamGeometry geometry = (StreamGeometry)elementPath.Data;
                StreamGeometryContext context = geometry.Open();
                geometry.Clone();
                
                PathFigureCollection pathFigureCollection = geometry.Figures;
                PathFigure startPathFigure = pathFigureCollection[0];
                Point startPoint = startPathFigure.StartPoint;
                */
                    // PathData pathData = new PathData();
            }
            // TODO
        }
    }
}
