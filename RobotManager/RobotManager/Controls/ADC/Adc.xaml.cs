namespace Org.Cen.RobotManager.Controls.ADC
{
    using System.Windows.Controls;
    using System.Windows;

    public partial class Adc : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }
        public Adc()
        {
            InitializeComponent();
        }
    }
}
