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
    public sealed partial class gamer : Page
    {
        public gamer()
        {
            this.InitializeComponent();
            Product product = new Product();
            var all_types = product.get_all_type();
            for (int i = 0; i <= (all_types.Length - 1); i++)
            {
                componants.Items.Add(all_types[i]);
            }
        }

        private void returnAtHome(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void componants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
