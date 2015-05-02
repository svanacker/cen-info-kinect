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
            Main.SendText("wc");
            Thread.Sleep(100);
            ReadPositionButton_Click(null, null);
        }

        private void ReadPositionButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            Main.SendText("wr");
            WheelPositionDataDecoder decoder = new WheelPositionDataDecoder();

            while (Main.receivedData.Length < decoder.GetDataLength(ReadWheelPositionInData.HEADER))
            {

            }
            ReadWheelPositionInData inData = (ReadWheelPositionInData)decoder.Decode(Main.receivedData.ToString());
            WheelPositionData wheelPositionData = inData.WheelPosition;
            LeftPositionValueLabel.Content = wheelPositionData.LeftPosition;
            RightPositionValueLabel.Content = wheelPositionData.RightPosition;
        }

        private void ReadRobotPositionButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            Main.SendText("nr");
            ReadRobotPositionDataDecoder decoder = new ReadRobotPositionDataDecoder();

            while (Main.receivedData.Length < decoder.GetDataLength(ReadRobotPositionInData.HEADER))
            {

            }
            ReadRobotPositionInData inData = (ReadRobotPositionInData)decoder.Decode(Main.receivedData.ToString());
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
            Main.SendText(outData.getMessage());

            UpdateCanvasRobotPosition(robotPosition);
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
            foreach (Path path in FindVisualChildren<Path>(Main.Main_Window))
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
            // UpdatePaths();
        }

        private void EnableRobotStrockeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // UpdatePaths();
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

        private void PositionGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Main.Position = this;
        }

    }
}
