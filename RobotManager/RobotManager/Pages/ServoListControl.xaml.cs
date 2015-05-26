namespace Org.Cen.RobotManager.Pages
{
    using System.Windows;
    using System.Windows.Controls;
    using Controls.Servo;

    /// <summary>
    /// Interaction logic for ServoListControl.xaml
    /// </summary>
    public partial class ServoListControl : UserControl
    {
        public const int SERVO_COUNT = 6;

        private ServoControl[] servoControls = new ServoControl[SERVO_COUNT];

        public ServoListControl()
        {
            InitializeComponent();
        }

        private void ServoListGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }
            servoControls[0] = Servo1;
            servoControls[1] = Servo2;
            servoControls[2] = Servo3;
            servoControls[3] = Servo4;
            servoControls[4] = Servo5;
            servoControls[5] = Servo6;
            for (int i = 0; i < SERVO_COUNT; i++)
            {
                int servoIndex = (i + 1);
                servoControls[i].ServoIndex = servoIndex;
                servoControls[i].ServoGroupBox.Header = "Servo " + servoIndex;
            }
        }
    }
}
