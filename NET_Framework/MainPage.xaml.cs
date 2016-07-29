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

        /// <summary>
        /// button_Gamer
        /// 
        /// Triggered when we click in the button, redirect in the gamer page
        /// 
        /// @param object; sender  the button
        /// @param PointerRoutedEventArgs e  the event that we don't use
        /// 
        /// @return void;
        /// </summary>
        private void button_Gamer(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(gamer));
        }

        /// <summary>
        /// button_Pro
        /// 
        /// Triggered when we click in the button, redirect in the pro page
        /// 
        /// @param object; sender  the button
        /// @param PointerRoutedEventArgs e  the event that we don't use
        /// 
        /// @return void;
        /// </summary>
        private void button_Pro(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(pro));
        }

        /// <summary>
        /// button_Desktop
        /// 
        /// Triggered when we click in the button, redirect in the dekstop page
        /// 
        /// @param object; sender  the button
        /// @param PointerRoutedEventArgs e  the event that we don't use
        /// 
        /// @return void;
        /// </summary>
        private void button_Desktop(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(desktop));
        }

        /// <summary>
        /// button_DesktopImage
        /// 
        /// Triggered when we click in the button, redirect in the desktop page
        /// 
        /// @param object; sender  the button
        /// @param PointerRoutedEventArgs e  the event that we don't use
        /// 
        /// @return void;
        /// </summary>
        private void button_DesktopImage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(desktop));
        }

        /// <summary>
        /// button_ProImage
        /// 
        /// Triggered when we click in the button, redirect in the pro page
        /// 
        /// @param object; sender  the button
        /// @param PointerRoutedEventArgs e  the event that we don't use
        /// 
        /// @return void;
        /// </summary>
        private void button_ProImage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(pro));
        }

        /// <summary>
        /// button_GamImage
        /// 
        /// Triggered when we click in the button, redirect in the gamer page
        /// 
        /// @param object; sender  the button
        /// @param PointerRoutedEventArgs e  the event that we don't use
        /// 
        /// @return void;
        /// </summary>
        private void button_GamImage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(gamer));
        }

        /// <summary>
        /// button_settingsImage
        /// 
        /// Triggered when we click in the button, redirect in the settings page
        /// 
        /// @param object; sender  the button
        /// @param PointerRoutedEventArgs e  the event that we don't use
        /// 
        /// @return void;
        /// </summary>
        private void button_settingsImage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(settings));
        }

        /// <summary>
        /// button_settings_Click
        /// 
        /// Triggered when we click in the button, redirect in the settings page
        /// 
        /// @param object; sender  the button
        /// @param PointerRoutedEventArgs e  the event that we don't use
        /// 
        /// @return void;
        /// </summary>
        private void button_setting_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(settings));
        }
    }
}
