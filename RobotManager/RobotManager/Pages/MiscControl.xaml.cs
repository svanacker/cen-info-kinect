﻿namespace Org.Cen.RobotManager.Pages
{
    using System.Windows;
    using System.Windows.Controls;


    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class MiscControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public MiscControl()
        {
            InitializeComponent();
        }
    }
}
