using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace NET_Framework
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class settings : Page
    {       

        public string id { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string price { get; set; }
        public string img { get; set; }
        public string type { get; set; }
        public string config { get; set; }

        public settings()
        {
            this.InitializeComponent();
            this.stuffs();
        }

        public async void stuffs()
        {
            Product stuffs = new Product();
            await stuffs.getMyStuffs();
            //System.Diagnostics.Debug.Write(stuffs.MyStuff);
        }

        /// <summary>
        /// returnAtHome
        /// 
        /// Triggered when we click in the button, redirect in the home page
        /// 
        /// @param object; sender  the button
        /// @param PointerRoutedEventArgs e  the event that we don't use
        /// 
        /// @return void;
        /// </summary>
        private void returnAtHome(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void text_settings_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

    }
}
