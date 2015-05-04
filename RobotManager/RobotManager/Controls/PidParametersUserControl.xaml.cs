namespace Org.Cen.RobotManager.Controls
{
    using System;
    using System.Windows.Controls;
    using Xceed.Wpf.Toolkit;

    /// <summary>
    /// Interaction logic for PidParametersUserControl.xaml
    /// </summary>
    public partial class PidParametersUserControl : UserControl
    {
        public PidParametersUserControl()
        {
            InitializeComponent();
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
    }
}
