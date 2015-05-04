namespace Org.Cen.RobotManager.Pages
{
    using System.Windows;
    using System.Windows.Controls;
    using UartWPFTest;

    /// <summary>
    /// Interaction logic for GameBoardControl.xaml
    /// </summary>
    public partial class GameBoardControl : UserControl
    {
        private MainWindow Main
        {
            get { return (MainWindow)Window.GetWindow(this); }
        }

        public GameBoardControl()
        {
            InitializeComponent();
        }

        private void GameBoardGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GameBoardScaleTransform.ScaleX = GameBoardGrid.RenderSize.Height / 300;
            GameBoardScaleTransform.ScaleY = -GameBoardGrid.RenderSize.Height / 300;
            GameBoardScaleTranslateTransform.Y = GameBoardGrid.RenderSize.Height;
            GameBoardCanvas.UpdateLayout();
        }
    }
}
