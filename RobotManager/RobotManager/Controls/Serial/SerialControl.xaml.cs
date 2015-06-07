namespace Org.Cen.RobotManager.Controls.Serial
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for SerialControl.xaml
    /// </summary>
    public partial class SerialControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow) Window.GetWindow(this); }
        }

        private Random _random;

        public SerialControl()
        {
            InitializeComponent();
            _random = new Random();
        }

        private long RandomInRange(long min, long max)
        {
            double value = _random.NextDouble() * (max - min) + min;
            return (long) value;
        }

        private void IntensiveSerialTestButton_Click(object sender, RoutedEventArgs e)
        {
            IntensiveSerialTestResultLabel.Content = "Start intensive test ...";
            bool ok = true;
            int testCount = int.Parse(TestCountTextBox.Text);
            for (int i = 0; i < testCount; i++)
            {
                Main.receivedData.Clear();
                StringBuilder s = new StringBuilder();
                
                s.Append("tW");
                int value1 = (int)RandomInRange(0, 0XFF);
                int value2 = (int)RandomInRange(0, 0XFF);
                int value3 = (int)RandomInRange(0, 0XFFFF);
                int value4 = (int)RandomInRange(0, 0XFFFF);
                int value5 = (int)RandomInRange(0, 0XFF);
                // Separator / value 6
                int value7 = (int)RandomInRange(0, 0XFF);
                int value8 = (int)RandomInRange(0, 0XFFFF);
                // avoid to use 0xFFFFF, because after it leads to an overflow on hex6 !
                long value9 = RandomInRange(0, 0XF0FFFF);
                int value10 = (int)RandomInRange(0, 0XFF);

                s.Append(value1.ToString("X2"));
                s.Append(value2.ToString("X2"));
                s.Append(value3.ToString("X4"));
                s.Append(value4.ToString("X4"));
                s.Append(value5.ToString("X2"));
                s.Append("-");
                s.Append(value7.ToString("X2"));
                s.Append(value8.ToString("X4"));
                s.Append(value9.ToString("X6"));
                s.Append(value10.ToString("X2"));

                Main.SendText(s.ToString());

                while (Main.receivedData.Length < 9)
                {
                }
                string resultAsString = Main.receivedData.ToString().Substring(3, 6);
                int actual = (int)int.Parse(resultAsString, NumberStyles.HexNumber);
                long expected = value1 + value2 + value3 + value4 + value5 + value7 + value8 + value9 + value10;

                if (actual != expected)
                {
                    ok = false;
                    IntensiveSerialTestResultLabel.Content = "KO (" + actual + "/" + expected + ")";
                    break;
                }
            }
            if (ok) { 
                IntensiveSerialTestResultLabel.Content = "OK !";
            }
        }
    }
}
