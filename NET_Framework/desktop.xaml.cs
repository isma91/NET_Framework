using System;
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
    public sealed partial class desktop : Page
    {
        public ProductViewModel ViewModel { get; set; }
        public Product product = new Product();

        /// <summary>
        /// desktop
        /// 
        /// Fullied the combobox with all type of Product to let the user
        /// choose the type he want
        /// 
        /// @return void;
        /// </summary>
        public desktop()
        {
            this.InitializeComponent();
            string[] all_types = this.product.get_all_type();
            for (int i = 0; i <= (all_types.Length -1); i++)
            {
                componants.Items.Add(all_types[i]);
            }
            this.ViewModel = new ProductViewModel();
        }

        /// <summary>
        /// componant_change
        /// 
        /// Triggered when we select something in the combobox, get the selected item who's the type of a Product
        /// and ask to get all componant of this type of Product
        /// 
        /// @param object; sender  the combobox
        /// @param PointerRoutedEventArgs e  the event that we don't use
        /// 
        /// @return void;
        /// </summary>
        private void componant_change(object sender, SelectionChangedEventArgs e)
        {
            string selected_item = componants.SelectedItem.ToString();
            string type = this.GetType().Name;
            List<Product> all_products = this.product.getContent(type, selected_item);
            this.ViewModel.addInList(all_products);
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

        /// <summary>
        /// Canvas_clicked
        /// 
        /// Triggered when we click in a canvas, get the tag of the canvas who's the id of the Product
        /// and save it in a specific file
        /// 
        /// @param object; sender  the canvas
        /// @param PointerRoutedEventArgs e  the event that we don't use
        /// 
        /// @return void;
        /// </summary>
        private async void Canvas_clicked(object sender, PointerRoutedEventArgs e)
        {
            Canvas canvas = (Canvas)sender;
            string name = (string)canvas.Tag;

            await this.product.save(name, componants.SelectedItem.ToString());
        }
    }
}
