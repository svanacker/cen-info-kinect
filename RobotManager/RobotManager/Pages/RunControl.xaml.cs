namespace Org.Cen.RobotManager.Pages
{
    using System.Windows;
    using System.Windows.Controls;
    using Devices.Motion.Simple.Com;
    using Devices.Motor.Com;

    /// <summary>
    /// Interaction logic for RunControl.xaml
    /// </summary>
    public partial class RunControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public RunControl()
        {
            InitializeComponent();
        }


        // forward

        public void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            int value = (int)ForwardSlider.Value;
            MotionSimpleForwardOutData outData = new MotionSimpleForwardOutData(value);
            string command = outData.GetMessage();
            Main.SendText(command);
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

        public void BackwardButton_Click(object sender, RoutedEventArgs e)
        {
            int value = (int)BackwardSlider.Value;

            MotionSimpleBackwardOutData outData = new MotionSimpleBackwardOutData(value);
            string command = outData.GetMessage();
            Main.SendText(command);
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

            MotionSimpleRotateLeftOutData outData = new MotionSimpleRotateLeftOutData(value);
            string command = outData.GetMessage();
            Main.SendText(command);
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
            MotionSimpleRotateRightOutData outData = new MotionSimpleRotateRightOutData(value);
            string command = outData.GetMessage();
            Main.SendText(command);
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            MotionSimpleStopOutData outData = new MotionSimpleStopOutData();
            string command = outData.GetMessage();
            Main.SendText(command);
        }

        // Go

        private void MotorGoButton_Click(object sender, RoutedEventArgs e)
        {
            int leftValue = (int)MotorLeftSlider.Value;
            int rightValue = (int)MotorRightSlider.Value;
            MotorWriteOutData outData = new MotorWriteOutData(leftValue, rightValue);

            string command = outData.GetMessage();
            Main.SendText(command);
        }

        private void MotorStopButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();

            MotorStopOutData outData = new MotorStopOutData();
            string command = outData.GetMessage();
            Main.SendText(command);

            while (Main.receivedData.Length < 3)
            {
            }
            LeftLabel.Content = Main.receivedData.ToString();

            Main.receivedData.Clear();
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

        private void RunPage_Loaded(object sender, RoutedEventArgs e)
        {
            ForwardSlider_ValueChanged(null, null);
            LeftSlider_ValueChanged(null, null);
            RightSlider_ValueChanged(null, null);
            BackwardSlider_ValueChanged(null, null);

            MotorLeftSlider_ValueChanged(null, null);
            MotorRightSlider_ValueChanged(null, null);
        }

        private void CalibrateButton_Click(object sender, RoutedEventArgs e)
        {
            MotionCalibrationOutData.CalibrationDirection direction = MotionCalibrationOutData.CalibrationDirection.Left;
            if (CalibrationRight.IsChecked != null && CalibrationRight.IsChecked.GetValueOrDefault())
            {
                direction = MotionCalibrationOutData.CalibrationDirection.Rigth;
            }
            int calibrationLength = int.Parse(CalibrationLengthTextBox.Text);
            MotionCalibrationOutData outData = new MotionCalibrationOutData(direction, calibrationLength);
            string message = outData.GetMessage();
            Main.SendText(message);
        }
    }
}
