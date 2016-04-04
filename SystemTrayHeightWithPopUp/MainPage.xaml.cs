using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Controls.Primitives;

namespace SystemTrayHeightWithPopUp
{
    public partial class MainPage : PhoneApplicationPage
    {
        double systemTrayHeight = 0;
        Popup popUp;
        public MainPage()
        {
            InitializeComponent();
            popUp = new Popup();
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                GeneralTransform gt = LayoutRoot.TransformToVisual(Application.Current.RootVisual as UIElement);
                Point offset = gt.Transform(new Point(0, 0));
                systemTrayHeight = offset.Y;
            }
            catch (Exception) { }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SetSystemTray();
        }


        public static void SetSystemTray()
        {
            try
            {
                SystemTray.BackgroundColor = Color.FromArgb(255, 250, 110, 40);
                SystemTray.ForegroundColor = Color.FromArgb(120, 245, 245, 245);
            }
            catch (Exception) { }
        }

        private void ShowPopUp_OnClick(object sender, RoutedEventArgs e)
        {
            popUp.VerticalOffset = systemTrayHeight;
            popUp.Child = new PopUp();
            popUp.IsOpen = true;
        }

        private void ClosePopUp_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.popUp != null && this.popUp.IsOpen)
                this.popUp.IsOpen = false;
        }

    }
}