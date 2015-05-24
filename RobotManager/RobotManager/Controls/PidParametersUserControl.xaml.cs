namespace Org.Cen.RobotManager.Controls
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using Devices.Pid;
    using Devices.Pid.Com;
    using UartWPFTest;
    using Xceed.Wpf.Toolkit;

    /// <summary>
    /// Interaction logic for PidParametersUserControl.xaml
    /// </summary>
    public partial class PidParametersUserControl : UserControl
    {
        public PidType Type { get; set; }

        public PidParametersUserControl()
        {
            InitializeComponent();
        }

        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        private void Spin_OnSpin(object sender, SpinEventArgs e)
        {
            ButtonSpinner spinner = (ButtonSpinner)sender;
            TextBox txtBox = (TextBox)spinner.Content;
            int value = String.IsNullOrEmpty(txtBox.Text) ? 0 : Convert.ToInt32(txtBox.Text);
            if (e.Direction == SpinDirection.Increase)
            {
                value++;
            }
            else
            {
                value--;
            }
            txtBox.Text = value.ToString();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            // THETA
            int baseIndex = (int)Type * 2;
            PIDReadOutData thetaOutData = new PIDReadOutData(baseIndex + (int)InstructionType.Theta);
            string thetaMessage = thetaOutData.GetMessage();
            Main.SendText(thetaMessage);

            PidReadInDataDecoder thetaDecoder = new PidReadInDataDecoder();

            while (Main.receivedData.Length < thetaDecoder.GetDataLength(PIDReadInData.HEADER))
            {

            }
            PIDReadInData thetaInData = (PIDReadInData)thetaDecoder.Decode(Main.receivedData.ToString());
            PidData thetaPidData = thetaInData.Data;

            ThetaPidPTextBox.Text = thetaPidData.P.ToString();
            ThetaPidITextBox.Text = thetaPidData.I.ToString();
            ThetaPidDTextBox.Text = thetaPidData.D.ToString();
            ThetaPidMiTextBox.Text = thetaPidData.MaxI.ToString();

            // ALPHA
            PIDReadOutData alphaOutData = new PIDReadOutData(baseIndex + (int)InstructionType.Theta);
            string alphaMessage = alphaOutData.GetMessage();
            Main.SendText(alphaMessage);

            PidReadInDataDecoder alphaDecoder = new PidReadInDataDecoder();

            while (Main.receivedData.Length < alphaDecoder.GetDataLength(PIDReadInData.HEADER))
            {

            }
            PIDReadInData alphaInData = (PIDReadInData)alphaDecoder.Decode(Main.receivedData.ToString());
            PidData alphaPidData = alphaInData.Data;

            AlphaPidPTextBox.Text = alphaPidData.P.ToString();
            AlphaPidITextBox.Text = alphaPidData.I.ToString();
            AlphaPidDTextBox.Text = alphaPidData.D.ToString();
            AlphaPidMiTextBox.Text = alphaPidData.MaxI.ToString();
        }

        private void WriteButton_Click(object sender, RoutedEventArgs e)
        {
            int baseIndex = (int) Type*2;

            // Theta
            int thetaP = int.Parse(ThetaPidPTextBox.Text);
            int thetaI = int.Parse(ThetaPidITextBox.Text);
            int thetaD = int.Parse(ThetaPidDTextBox.Text);
            int thetaMaxI = int.Parse(ThetaPidMiTextBox.Text);

            PidData thetaPidData = new PidData(thetaP, thetaI, thetaD, thetaMaxI);
            PIDWriteOutData thetaOutData = new PIDWriteOutData(baseIndex + (int) InstructionType.Theta, thetaPidData);
            string thetaMessage = thetaOutData.GetMessage();
            Main.SendText(thetaMessage);

            // Alpha
            int alphaP = int.Parse(AlphaPidPTextBox.Text);
            int alphaI = int.Parse(AlphaPidITextBox.Text);
            int alphaD = int.Parse(AlphaPidDTextBox.Text);
            int alphaMaxI = int.Parse(AlphaPidMiTextBox.Text);

            PidData alphaPidData = new PidData(alphaP, alphaI, alphaD, alphaMaxI);
            PIDWriteOutData outData = new PIDWriteOutData(baseIndex + (int)InstructionType.Alpha, alphaPidData);
            string alphaMessage = outData.GetMessage();
            Main.SendText(alphaMessage);
        }
    }
}
