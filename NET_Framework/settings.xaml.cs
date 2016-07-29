using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using System.Xml;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace NET_Framework
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class settings : Page
    {
        public ProductViewModel ViewModel { get; set; }
        public Product product = new Product();
        public List<Product> ListProduct = new List<Product>();

        public settings()
        {
            this.InitializeComponent();
            this.ViewModel = new ProductViewModel();
            this.getMyStuffs();
        }

        /*
         * removeConfig private method
         * 
         * event on click on page
         * 
         * remove the config.xml in local app data
         */
        private void removeConfig(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.removeFile();
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
        /// convertBigListProductToOneListProduct
        /// 
        /// Convert the List<Product> in a List<Product> of one element
        /// 
        /// @param List<Product> list  the big list of many Product elements
        /// 
        /// @return List<Product>;
        /// </summary>
        public List<Product> convertBigListProductToOneListProduct(List<Product> list)
        {
            List<Product> tmp_list_product = new List<Product>();
            string tmp_graph = "";
            string tmp_mem = "";
            string tmp_mother = "";
            string tmp_disk = "";
            string tmp_proc = "";
            foreach (Product componant in list)
            {
                switch ((string)componant.Type)
                {
                    case ("Graphic_card"):
                        tmp_graph = componant.Name;
                        break;
                    case ("memory"):
                        tmp_mem = componant.Name;
                        break;
                    case ("Motherboard"):
                        tmp_mother = componant.Name;
                        break;
                    case ("disk"):
                        tmp_disk = componant.Name;
                        break;
                    case ("Processor"):
                        tmp_proc = componant.Name;
                        break;
                }
            }
            tmp_list_product.Add(new Product()
            {
                Id = tmp_graph,
                Name = tmp_mother,
                Company = tmp_proc,
                Type = tmp_disk,
                Config = tmp_mem
            });

            return tmp_list_product;
        }

        private void text_settings_SelectionChanged(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// getMyStuffs
        /// 
        /// Get saving stuff if the file exist
        /// 
        /// @return void;
        /// </summary>
        public async void getMyStuffs()
        {
            StorageFolder getfolder = ApplicationData.Current.LocalFolder;
            StorageFolder getnewFolder = await getfolder.CreateFolderAsync("config", CreationCollisionOption.OpenIfExists);
            IReadOnlyList<StorageFile> getfiles = await getnewFolder.GetFilesAsync();
            StorageFile desiredFile = getfiles.FirstOrDefault(x => x.Name == "config.xml");
            string textContent = await FileIO.ReadTextAsync(desiredFile);
            XmlReader xReader = XmlReader.Create(new StringReader(textContent));
            xReader.ReadStartElement("Product");
            while (xReader.Read())
            {
                string type = xReader.Name; // graphic card
                string type2 = type.Replace("_", " ");
                string id = xReader.ReadOuterXml(); // id
                string id1 = id.Replace("<" + type + ">", "");
                string id2 = id1.Replace("</" + type + ">", "");
                this.ListProduct.Add(new Product()
                {
                    Id = "",
                    Name = id2,
                    Company = "",
                    Price = "",
                    Img = "",
                    Type = type,
                    Config = ""
                });
            }
            List<Product> the_final_list = this.convertBigListProductToOneListProduct(this.ListProduct);
            this.ViewModel.addInList(the_final_list);
        }
    }
}
