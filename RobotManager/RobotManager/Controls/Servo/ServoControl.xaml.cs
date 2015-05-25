namespace Org.Cen.RobotManager.Controls.Servo
{
    using System.Windows;
    using System.Windows.Controls;

    using Devices.Servo;
    using Devices.Servo.Com;

    /// <summary>
    /// Interaction logic for ServoControl.xaml
    /// </summary>
    public partial class ServoControl : UserControl
    {
        public int ServoIndex { get; set; }

        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }


        public ServoControl()
        {
            InitializeComponent();
        }

        private void ReadServo()
        {
            Main.receivedData.Clear();
            ServoReadParametersOutData outData = new ServoReadParametersOutData(ServoIndex);
            string message = outData.GetMessage();
            Main.SendText(message);

            ServoReadParametersInDataDecoder decoder = new ServoReadParametersInDataDecoder();
            while (Main.receivedData.Length < decoder.GetDataLength(ServoReadParametersOutData.Header))
            {

            }
            ServoReadParametersInData inData = (ServoReadParametersInData)decoder.Decode(Main.receivedData.ToString());

            ServoData servoData = inData.Data;

            ServoSpeedSlider.Value = servoData.ServoSpeed;
            ServoTargetPositionSlider.Value = servoData.ServoTargetPosition;
            ServoCurrentPositionValueLabel.Content = servoData.ServoCurrentPosition.ToString();
        }

        private void WriteServo()
        {
            int servoSpeed = (int ) ServoSpeedSlider.Value;
            int servoTargetPosition = (int)ServoTargetPositionSlider.Value;

            ServoData servoData = new ServoData(ServoIndex, servoSpeed, servoTargetPosition);
            ServoWriteParametersOutData outData = new ServoWriteParametersOutData(servoData);
            string message = outData.GetMessage();
            Main.SendText(message);
        }

        // Event Management

        private void ReadServoParametersButton_Click(object sender, RoutedEventArgs e)
        {
            ReadServo();
        }

        private void ServoSpeedSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            WriteServo();
        }

        private void ServoTargetPositionSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            WriteServo();
        }
    }
}
