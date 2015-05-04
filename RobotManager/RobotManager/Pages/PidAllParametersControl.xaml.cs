using System.Windows.Controls;

namespace Org.Cen.RobotManager.Pages
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for PidAllParametersControl.xaml
    /// </summary>
    public partial class PidAllParametersControl : UserControl
    {
        public PidAllParametersControl()
        {
            InitializeComponent();
        }

        private void PidAllParametersControlGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            PidTypeGoControl.PidTypeGroupBox.Header = "Go/Back";
            PidTypeRotateControl.PidTypeGroupBox.Header = "Rotate";
            PidTypeMaintainControl.PidTypeGroupBox.Header = "Maintain Position";
            PidTypeAdjustDirection.PidTypeGroupBox.Header = "Adjust Direction";
            PidTypeFinalApproach.PidTypeGroupBox.Header = "Final Approach";
        }
    }
}
