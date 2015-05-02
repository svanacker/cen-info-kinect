namespace Org.Cen.RobotManager.Pages
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using Com.Utils;
    using UartWPFTest;

    /// <summary>
    /// Interaction logic for RunPage.xaml
    /// </summary>
    public partial class RunPage : Page
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public RunPage()
        {
            InitializeComponent();
        }


        // forward

        public void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            int value = (int)ForwardSlider.Value;
            string hexValue = ComDataUtils.format(value, 4);
            string command = "Mf" + hexValue;
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
            string hexValue = ComDataUtils.format(value, 4);
            string command = "Mb" + hexValue;
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
            string hexValue = ComDataUtils.format(value, 4);
            string command = "Ml" + hexValue;
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
            string hexValue = ComDataUtils.format(value, 4);
            string command = "Mr" + hexValue;
            Main.SendText(command);
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            Main.SendText("Mc");
        }

        // Go

        private void MotorGoButton_Click(object sender, RoutedEventArgs e)
        {
            int leftValue = (int)MotorLeftSlider.Value;
            string hexLeftValue = ComDataUtils.format(leftValue, 2);
            int rightValue = (int)MotorLeftSlider.Value;
            string hexRightValue = ComDataUtils.format(rightValue, 2);
            string command = "mw" + hexLeftValue + hexRightValue;
            Main.SendText(command);
        }


        private void MotorStopButton_Click(object sender, RoutedEventArgs e)
        {
            Main.receivedData.Clear();
            Main.SendText("mc");

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

        private void Window_Initialized(object sender, EventArgs e)
        {
            ForwardSlider_ValueChanged(null, null);
            LeftSlider_ValueChanged(null, null);
            RightSlider_ValueChanged(null, null);
            BackwardSlider_ValueChanged(null, null);

            MotorLeftSlider_ValueChanged(null, null);
            MotorRightSlider_ValueChanged(null, null);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Main.Run = this;
        }
    }
}
