namespace Org.Cen.RobotManager.Pages
{
    using System.Windows;
    using System.Windows.Controls;

    using Devices.Robot;
    using Devices.Robot.End.Com;
    using Devices.Robot.Start.Com;
    using UartWPFTest;
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class MiscPage : Page
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public MiscPage()
        {
            InitializeComponent();
        }

        private void MiscGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Main.Misc = this;
        }
    }
}
