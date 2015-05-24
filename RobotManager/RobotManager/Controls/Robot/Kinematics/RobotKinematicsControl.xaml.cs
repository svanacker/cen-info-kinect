namespace Org.Cen.RobotManager.Controls.Robot.Kinematics
{
    using System.Windows;
    using System.Windows.Controls;
    using Devices.Robot.Kinematics;

    /// <summary>
    /// Interaction logic for RobotKinematicsControl.xaml
    /// </summary>
    public partial class RobotKinematicsControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public RobotKinematicsControl()
        {
            InitializeComponent();
        }

        // LoadDefaultValues

        private void KinematicsLoadDefaultValues()
        {
            RobotKinematicsLoadDefaultValuesOutData outData = new RobotKinematicsLoadDefaultValuesOutData();
            string message = outData.GetMessage();
            Main.SendText(message);
        }

        private void KinematicsLoadDefaultValueButton_Click(object sender, RoutedEventArgs e)
        {
            KinematicsLoadDefaultValues();
            KinematicsReadAll();
        }

        // Write

        private void WritePulseByRotation()
        {
            int value = int.Parse(PulseByRotationTextBox.Text);
            RobotKinematicsPulseByRotationWriteOutData outData = new RobotKinematicsPulseByRotationWriteOutData(value);
            string message = outData.GetMessage();
            Main.SendText(message);
            // Wait for the response
            while (Main.receivedData.Length < 3)
            {

            }
        }

        private void WriteRotationBySecondAtFullSpeed()
        {
            int value = int.Parse(RotationBySecondAtFullSpeedTextBox.Text);
            RobotKinematicsRotationBySecondAtFullSpeedWriteOutData outData = new RobotKinematicsRotationBySecondAtFullSpeedWriteOutData(value);
            string message = outData.GetMessage();
            Main.SendText(message);
            // Wait for the response
            while (Main.receivedData.Length < 3)
            {

            }
        }

        private void WriteWheelDeltaForOnePulseLength()
        {
            int value = int.Parse(WheelDeltaForOnePulseLengthTextBox.Text);
            RobotKinematicsWheelDeltaForOnePulseLengthWriteOutData outData = new RobotKinematicsWheelDeltaForOnePulseLengthWriteOutData(value);
            string message = outData.GetMessage();
            Main.SendText(message);
            // Wait for the response
            while (Main.receivedData.Length < 3)
            {

            }
        }

        private void WriteWheelsAverageForOnePulseLength()
        {
            int value = int.Parse(WheelsAverageForOnePulseLengthTextBox.Text);
            RobotKinematicsWheelsAverageForOnePulseLengthWriteOutData outData = new RobotKinematicsWheelsAverageForOnePulseLengthWriteOutData(value);
            string message = outData.GetMessage();
            Main.SendText(message);
            // Wait for the response
            while (Main.receivedData.Length < 3)
            {

            }
        }

        private void WriteWheelsDistance()
        {
            int value = int.Parse(WheelDistanceTextBox.Text);
            RobotKinematicsWheelsDistanceWriteOutData outData = new RobotKinematicsWheelsDistanceWriteOutData(value);
            string message = outData.GetMessage();
            Main.SendText(message);

            // Wait for the response
            while (Main.receivedData.Length < 3)
            {

            }
        }

        private void KinematicsWriteAll()
        {
            WritePulseByRotation();
            WriteRotationBySecondAtFullSpeed();
            WriteWheelDeltaForOnePulseLength();
            WriteWheelsAverageForOnePulseLength();
            WriteWheelsDistance();
        }

        private void KinematicsWriteAllButton_Click(object sender, RoutedEventArgs e)
        {
            KinematicsWriteAll();
        }

        // Read


        private void ReadPulseByRotation()
        {
            Main.receivedData.Clear();
            RobotKinematicsPulseByRotationReadOutData outData = new RobotKinematicsPulseByRotationReadOutData();
            string message = outData.GetMessage();
            Main.SendText(message);
            
            RobotKinematicsPulseByRotationReadInDataDecoder decoder = new RobotKinematicsPulseByRotationReadInDataDecoder();
            while (Main.receivedData.Length < decoder.GetDataLength(RobotKinematicsPulseByRotationReadOutData.Header))
            {

            }
            RobotKinematicsPulseByRotationReadInData inData = (RobotKinematicsPulseByRotationReadInData)decoder.Decode(Main.receivedData.ToString());
            PulseByRotationTextBox.Text = inData.Value.ToString();
        }

        private void ReadRotationBySecondAtFullSpeed()
        {
            Main.receivedData.Clear();
            RobotKinematicsRotationBySecondAtFullSpeedReadOutData outData = new RobotKinematicsRotationBySecondAtFullSpeedReadOutData();
            string message = outData.GetMessage();
            Main.SendText(message);

            RobotKinematicsRotationBySecondAtFullSpeedReadInDataDecoder decoder = new RobotKinematicsRotationBySecondAtFullSpeedReadInDataDecoder();
            while (Main.receivedData.Length < decoder.GetDataLength(RobotKinematicsRotationBySecondAtFullSpeedReadOutData.Header))
            {

            }
            RobotKinematicsRotationBySecondAtFullSpeedReadInData inData = (RobotKinematicsRotationBySecondAtFullSpeedReadInData)decoder.Decode(Main.receivedData.ToString());
            RotationBySecondAtFullSpeedTextBox.Text = inData.Value.ToString();
        }

        private void ReadWheelDeltaForOnePulseLength()
        {
            Main.receivedData.Clear();
            RobotKinematicsWheelDeltaForOnePulseLengthReadOutData outData = new RobotKinematicsWheelDeltaForOnePulseLengthReadOutData();
            string message = outData.GetMessage();
            Main.SendText(message);

            RobotKinematicsWheelDeltaForOnePulseLengthReadInDataDecoder decoder = new RobotKinematicsWheelDeltaForOnePulseLengthReadInDataDecoder();
            while (Main.receivedData.Length < decoder.GetDataLength(RobotKinematicsWheelDeltaForOnePulseLengthReadOutData.Header))
            {

            }
            RobotKinematicsWheelDeltaForOnePulseLengthReadInData inData = (RobotKinematicsWheelDeltaForOnePulseLengthReadInData)decoder.Decode(Main.receivedData.ToString());
            WheelDeltaForOnePulseLengthTextBox.Text = inData.Value.ToString();
        }

        private void ReadWheelsAverageForOnePulseLength()
        {
            Main.receivedData.Clear();
            RobotKinematicsWheelsAverageForOnePulseLengthReadOutData outData = new RobotKinematicsWheelsAverageForOnePulseLengthReadOutData();
            string message = outData.GetMessage();
            Main.SendText(message);

            RobotKinematicsWheelsAverageForOnePulseLengthReadInDataDecoder decoder = new RobotKinematicsWheelsAverageForOnePulseLengthReadInDataDecoder();
            while (Main.receivedData.Length < decoder.GetDataLength(RobotKinematicsWheelsAverageForOnePulseLengthReadOutData.Header))
            {

            }
            RobotKinematicsWheelsAverageForOnePulseLengthReadInData inData = (RobotKinematicsWheelsAverageForOnePulseLengthReadInData)decoder.Decode(Main.receivedData.ToString());
            WheelsAverageForOnePulseLengthTextBox.Text = inData.Value.ToString();
        }

        private void ReadWheelsDistance()
        {
            Main.receivedData.Clear();
            RobotKinematicsWheelsDistanceReadOutData outData = new RobotKinematicsWheelsDistanceReadOutData();
            string message = outData.GetMessage();
            Main.SendText(message);

            RobotKinematicsWheelsDistanceReadInDataDecoder decoder = new RobotKinematicsWheelsDistanceReadInDataDecoder();
            while (Main.receivedData.Length < decoder.GetDataLength(RobotKinematicsWheelsDistanceReadOutData.Header))
            {

            }
            RobotKinematicsWheelsDistanceReadInData inData = (RobotKinematicsWheelsDistanceReadInData)decoder.Decode(Main.receivedData.ToString());
            WheelDistanceTextBox.Text = inData.Value.ToString();
        }

        private void KinematicsReadAll()
        {
            ReadPulseByRotation();
            ReadRotationBySecondAtFullSpeed();
            ReadWheelDeltaForOnePulseLength();
            ReadWheelsAverageForOnePulseLength();
            ReadWheelsDistance();
        }

        private void KinematicsReadAllButton_Click(object sender, RoutedEventArgs e)
        {
            KinematicsReadAll();
        }
    }
}
