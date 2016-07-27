using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Windows.UI.Popups;
using System.Collections.ObjectModel;

namespace NET_Framework
{
    public class Product
    {
        public string id { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string price { get; set; }
        public string img { get; set; }
        public string type { get; set; }
        public string config { get; set; }
        private string file_name = "stuffs.json";
        private JObject json { get; set; }

        public Product()
        {
            try
            {
                JObject json = JObject.Parse(File.ReadAllText(this.file_name));
                this.json = json;
            }
            catch (FileNotFoundException)
            {
                System.Diagnostics.Debug.WriteLine("The file " + this.file_name + " was not found !!");
            }
        }

        private void show_dialog(string title, string message)
        {
            MessageDialog message_dialog = new MessageDialog(message, title);
            message_dialog.Commands.Clear();
            message_dialog.Commands.Add(new UICommand("Ok"));
            message_dialog.Commands.Add(new UICommand("Quit App", new UICommandInvokedHandler(this.Quit)));
            message_dialog.ShowAsync();
        }
        /*
         * get_all_type 
         * 
         * check in the json file all differents type of componants
         * 
         * return array of string
         */
        public string[] get_all_type()
        {
            int length = this.json["products"].Count();
            string[] types = new string[length];
            int count = 0;
            foreach (var product in this.json["products"])
            {
                types[count] = (string)product["type"];
                count++;
            }
            string[] all_types = types.Distinct().ToArray();
            return all_types;
        }

        /*
         * getContent return an array
         * 
         * @param string config, string type
         */
        public List<Product> getContent(string config, string type)
        {
            int length = this.json["products"].Count();
            string[] types = new string[length];
            List<Product> product = new List<Product>();
            foreach (var test in this.json["products"])
            {
                if (config == (string)test["config"] && type == (string)test["type"])
                {
                    product.Add(new Product()
                    {
                        id = (string)test["id"],
                        name = (string)test["name"],
                        company = (string)test["company"],
                        price = (string)test["price"],
                        img = (string)test["img"],
                        type = (string)test["type"],
                        config = (string)test["config"]
                    });
                }
            }
            return product;
        }

        private void Quit(IUICommand command)
        {
            Windows.ApplicationModel.Core.CoreApplication.Exit();
        }
    }
    public class ProductViewModel
    {
        private ObservableCollection<Product> productList = new ObservableCollection<Product>();
        public ObservableCollection<Product> ProductList { get { return this.productList; } }
        public ProductViewModel()
        {
            this.productList.Add(new NET_Framework.Product()
            {
                id = "0",
                name = "Geforce GTX 1080",
                company = "nVidia",
                price = "1000$",
                img = "Assest/gforce.png",
                type = "type",
                config = "config"
            });
            this.productList.Add(new NET_Framework.Product()
            {
                id = "1",
                name = "Geforce GTX 980",
                company = "nVidia",
                price = "900$",
                img = "Assest/gforce.png",
                type = "type",
                config = "config"
            });
        }
    }
}
