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
        public List<Product> product = new List<Product>();
        public string Graphic_card;
        public string Motherboard;
        public string Processor;
        public string Disk;
        public string Memory;

        public settings()
        {
            this.InitializeComponent();
            this.getMyStuffs();
            /*this.Graphic_card = "Nvidia";
            this.Motherboard = "ATI";
            this.Processor = "Intel";
            this.Disk = "Kingstone";
            this.Memory = "Corsair";*/
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
                this.product.Add(new Product()
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
        }
    }
}
