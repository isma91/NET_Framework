using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace NET_Framework
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class pro : Page
    {
        public ProductViewModel ViewModel { get; set; }
        public Product product = new Product();
        public pro()
        {
            this.InitializeComponent();
            string[] all_types = this.product.get_all_type();
            for (int i = 0; i <= (all_types.Length - 1); i++)
            {
                componants.Items.Add(all_types[i]);
            }
            this.ViewModel = new ProductViewModel();
        }

        private void returnAtHome(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void componant_change(object sender, SelectionChangedEventArgs e)
        {
            string selected_item = componants.SelectedItem.ToString();
            string type = this.GetType().Name;
            List<Product> all_products = this.product.getContent(type, selected_item);
            this.ViewModel.addInList(all_products);
        }

        private async void Canvas_clicked(object sender, PointerRoutedEventArgs e)
        {
            Canvas canvas = (Canvas)sender;
            int id = (int)canvas.Tag;
            await this.product.save(id, componants.SelectedItem.ToString());
        }
    }
}
