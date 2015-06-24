namespace Org.Cen.RobotManager.Pages
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for RawDataControl.xaml
    /// </summary>
    public partial class RawDataControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public RawDataControl()
        {
            InitializeComponent();
        }
    }
}
