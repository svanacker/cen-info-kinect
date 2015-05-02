using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Org.Cen.RobotManager.Pages
{
    using UartWPFTest;

    /// <summary>
    /// Interaction logic for RawDataPage.xaml
    /// </summary>
    public partial class RawDataPage : Page
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public RawDataPage()
        {
            InitializeComponent();
        }

        private void MotionGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Main.RawData = this;
        }
    }
}
