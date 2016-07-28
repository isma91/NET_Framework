using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
        public ProductViewModel ViewModel { get; set; }
        public desktop()
        {
            this.InitializeComponent();
            Product product = new Product();
            var all_types = product.get_all_type();
            for (int i = 0; i <= (all_types.Length -1); i++)
            {
                componants.Items.Add(all_types[i]);
            }
        }

        private void componant_change(object sender, SelectionChangedEventArgs e)
        {
            Object selected_item = componants.SelectedItem.ToString();
            Product product = new Product();
            List<Product> all_products = product.getContent("desktop", selected_item);
            ViewModel = new ProductViewModel();
            ViewModel.addInList(all_products);
        }

        private void returnAtHome(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Canvas_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("entered");
        }
    }
}
