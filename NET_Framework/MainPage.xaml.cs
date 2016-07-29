using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NET_Framework
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void button_Gamer(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(gamer));
        }

        private void button_Pro(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(pro));
        }

        private void button_Desktop(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(desktop));
        }

        private void button_DesktopImage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(desktop));
        }

        private void button_ProImage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(pro));
        }

        private void button_GamImage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(gamer));
        }

        private void button_settingsImage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(settings));
        }

        private void button_setting_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(settings));
        }
    }
}
