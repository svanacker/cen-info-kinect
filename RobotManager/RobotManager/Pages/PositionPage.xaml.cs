namespace Org.Cen.RobotManager.Pages
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;

    using System.Threading;
    using Devices.Motion.Position;
    using Devices.Motion.Position.Com;
    using Org.Com.Devices.Motion.Position;
    using UartWPFTest;

    /// <summary>
    /// Interaction logic for PositionPage.xaml
    /// </summary>
    public partial class PositionPage : Page
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public PositionPage()
        {
            InitializeComponent();
        }

        private void ClearPositionButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            WheelPositionClearOutData outData = new WheelPositionClearOutData();
            string command = outData.getMessage();
            Main.SendText(command);
            Thread.Sleep(100);
            ReadPositionButton_Click(null, null);
        }

        private void ReadPositionButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            WheelPositionReadOutData outData = new WheelPositionReadOutData();
            string command = outData.getMessage();
            Main.SendText(command);

            WheelPositionReadInDataDecoder decoder = new WheelPositionReadInDataDecoder();

            while (Main.receivedData.Length < decoder.GetDataLength(WheelPositionReadInData.HEADER))
            {

            }
            WheelPositionReadInData inData = (WheelPositionReadInData)decoder.Decode(Main.receivedData.ToString());
            WheelPositionData wheelPositionData = inData.WheelPosition;
            LeftPositionValueLabel.Content = wheelPositionData.LeftPosition;
            RightPositionValueLabel.Content = wheelPositionData.RightPosition;
        }

        private void ReadRobotPositionButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            Main.SendText("nr");
            RobotPositionReadInDataDecoder decoder = new RobotPositionReadInDataDecoder();

            while (Main.receivedData.Length < decoder.GetDataLength(RobotPositionReadInData.HEADER))
            {

            }
            RobotPositionReadInData inData = (RobotPositionReadInData)decoder.Decode(Main.receivedData.ToString());
            RobotPosition robotPosition = inData.Position;

            XTextBox.Text = robotPosition.X.ToString();
            YTextBox.Text = robotPosition.Y.ToString();
            AngleTextBox.Text = robotPosition.DeciDegreeAngle.ToString();

            UpdateCanvasRobotPosition(robotPosition);
        }

        public void UpdateCanvasRobotPosition(RobotPosition robotPosition)
        {
            /* TODO
            RobotPositionTranslateTransform.X = robotPosition.X / 10.0d;
            RobotPositionTranslateTransform.Y = robotPosition.Y / 10.0d;
            RobotPositionRotateTransform.Angle = robotPosition.DeciDegreeAngle / 10.0d;
            */
        }

        private void WriteRobotPositionButton_Click(object sender, RoutedEventArgs e)
        {
            RobotPosition robotPosition = new RobotPosition();
            robotPosition.X = int.Parse(XTextBox.Text);
            robotPosition.Y = int.Parse(YTextBox.Text);
            robotPosition.DeciDegreeAngle = int.Parse(AngleTextBox.Text);

            WriteRobotPositionOutData outData = new WriteRobotPositionOutData(robotPosition);
            Main.SendText(outData.getMessage());

            UpdateCanvasRobotPosition(robotPosition);
        }

        public void UpdatePaths()
        {
            foreach (Path path in FindVisualChildren<Path>(Main.Main_Window))
            {
                /* TODO
                if (path.Equals(Robot))
                {
                    continue;
                }
                */
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
            // TODO : UpdatePaths();
        }

        private void EnableRobotStrockeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // TODO : UpdatePaths();
        }

        private void ShowRobotCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            /* TODO
            if (ShowRobotCheckBox.IsChecked == true)
            {
                Robot.Visibility = Visibility.Visible;
            }
            else
            {
                Robot.Visibility = Visibility.Hidden;
            }
            */ 
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

        private void PositionGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Main.Position = this;
        }

    }
}
