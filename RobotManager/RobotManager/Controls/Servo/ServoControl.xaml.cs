namespace Org.Cen.RobotManager.Controls.Servo
{
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using Devices.Servo;
    using Devices.Servo.Com;

    /// <summary>
    /// Interaction logic for ServoControl.xaml
    /// </summary>
    public partial class ServoControl : UserControl
    {
        public int ServoIndex { get; set; }

        private bool readValue = false;

        private bool speedDragStarted = false;
        private bool targetPositionDragStarted = false;

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
            while (Main.receivedData.Length < decoder.GetDataLength(null))
            {
            }
            ServoReadParametersInData inData = (ServoReadParametersInData)decoder.Decode(Main.receivedData.ToString());

            ServoData servoData = inData.Data;

            readValue = true;
            ServoSpeedSlider.Value = servoData.ServoSpeed;
            ServoTargetPositionSlider.Value = servoData.ServoTargetPosition;
            ServoCurrentPositionValueLabel.Content = servoData.ServoCurrentPosition.ToString();
            readValue = false;
        }

        private void WriteServo()
        {
            if (Main == null)
            {
                return;
            }
            int servoSpeed = (int ) ServoSpeedSlider.Value;
            int servoTargetPosition = (int)ServoTargetPositionSlider.Value;
            ServoSpeedValueLabel.Content = servoSpeed.ToString();
            ServoTargetPositionValueLabel.Content = servoTargetPosition.ToString();

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

        // Speed

        private void ServoSpeedSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (readValue || speedDragStarted)
            {
                return;
            }
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }
            WriteServo();
        }


        private void ServoSpeedSlider_OnDragStarted(object sender, DragStartedEventArgs e)
        {
            speedDragStarted = true;
        }

        private void ServoSpeedSlider_OnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            WriteServo();
            speedDragStarted = false;
        }

        // target Position

        private void ServoTargetPositionSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (readValue || targetPositionDragStarted)
            {
                return;
            }
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }
            WriteServo();
        }

        private void ServoTargetPositionSlider_OnDragStarted(object sender, DragStartedEventArgs e)
        {
            targetPositionDragStarted = true;
        }

        private void ServoTargetPositionSlider_OnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            WriteServo();
            targetPositionDragStarted = false;
        }
    }
}
