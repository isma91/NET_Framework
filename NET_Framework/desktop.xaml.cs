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
    public sealed partial class desktop : Page
    {
        public desktop()
        {
            this.InitializeComponent();
            Product product = new Product();
            product.get_all_type();
            ComboBox components = new ComboBox();
            componants.Items.Add("A");
            componants.Items.Add("B");
            componants.Items.Add("C");
        }

        private void componant_change(object sender, SelectionChangedEventArgs e)
        {
            Object selected_item = componants.SelectedItem;
            System.Diagnostics.Debug.WriteLine("Selected item = " + selected_item.ToString());
        }

        private void returnAtHome(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
