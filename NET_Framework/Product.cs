using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Windows.UI.Popups;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.Storage;
using System.ComponentModel;

namespace NET_Framework
{
    public class Product : INotifyPropertyChanged
    {
        private string id;
        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                NotifyPropertyChanged("Id");
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                NotifyPropertyChanged("Name");
            }
        }
        private string company;
        public string Company
        {
            get
            {
                return this.company;
            }
            set
            {
                this.company = value;
                NotifyPropertyChanged("Company");
            }
        }
        private string price;
        public string Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
                NotifyPropertyChanged("Price");
            }
        }
        private string img;
        public string Img
        {
            get
            {
                return this.img;
            }
            set
            {
                this.img = value;
                NotifyPropertyChanged("Img");
            }
        }
        private string type;
        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
                NotifyPropertyChanged("Type");
            }
        }
        private string config;
        public string Config
        {
            get
            {
                return this.config;
            }
            set
            {
                this.config = value;
                NotifyPropertyChanged("Config");
            }
        }
        private string file_name = "stuffs.json";
        private JObject json { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Product()
        {
            try
            {
                JObject json = JObject.Parse(File.ReadAllText(this.file_name));
                this.json = json;
            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine("The file " + this.file_name + " was not found !!");
            }
        }

        private void show_dialog(string title, string message)
        {
            MessageDialog message_dialog = new MessageDialog(message, title);
            message_dialog.Commands.Clear();
            message_dialog.Commands.Add(new UICommand("Ok"));
            message_dialog.Commands.Add(new UICommand("Quit App", new UICommandInvokedHandler(this.Quit)));
            //message_dialog.ShowAsync();
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
         * getContent
         * 
         * @param string config, string type
         * @return List<Product>
         */
        public List<Product> getContent (string config, string type)
        {
            int length = this.json["products"].Count();
            string[] types = new string[length];

            List<Product> product = new List<Product>();

            foreach (var compo in this.json["products"])
            {
                if (config == (string)compo["config"] && type == (string)compo["type"])
                {
                    product.Add(new Product()
                    {
                        Id = (string)compo["id"],
                        Name = (string)compo["name"],
                        Company = (string)compo["company"],
                        Price = (string)compo["price"],
                        Img = "Assets/" + (string)compo["img"],
                        Type = (string)compo["type"],
                        Config = (string)compo["config"]
                    });
                }
            }

            return product;
        }

        /*
         * save method
         * 
         * async method for saving id of item in a file json
         * 
         * @param int id
         * @return Task
         */
        public async Task save (int id, string type)
        {
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            var folder = ApplicationData.Current.LocalFolder;
            var newFolder = await folder.CreateFolderAsync("config", CreationCollisionOption.OpenIfExists);

            var textFile = await newFolder.CreateFileAsync("config.xml", CreationCollisionOption.OpenIfExists);
            await FileIO.WriteTextAsync(textFile, "{'1', '2', '3', '4'}");
            //await FileIO.WriteTextAsync(textFile, type);

            var getfolder = ApplicationData.Current.LocalFolder;
            var getnewFolder = await getfolder.CreateFolderAsync("config", CreationCollisionOption.OpenIfExists);
            var getfiles = await getnewFolder.GetFilesAsync();

            var desiredFile = getfiles.FirstOrDefault(x => x.Name == "config.xml");
            var textContent = await FileIO.ReadTextAsync(desiredFile);

            var allJson = JObject.Parse(textContent);

            Debug.WriteLine(allJson);

        }

        /*
         * getMyStuffs method
         * 
         * get saving stuffs file if exists
         * and return all id in json
         * 
         * @return json
         */
        public async Task getMyStuffs ()
        {
            var folder = ApplicationData.Current.LocalFolder;
            var newFolder = await folder.CreateFolderAsync("config", CreationCollisionOption.OpenIfExists);
            var files = await newFolder.GetFilesAsync();

            var desiredFile = files.FirstOrDefault(x => x.Name == "config.xml");
            var textContent = await FileIO.ReadTextAsync(desiredFile);
            Debug.WriteLine(textContent);

            //return List<Product>;
        }

        /*
         * getContentById method
         * 
         * @param int id
         * @return List<Product>
         */
        public List<Product> getContentById (int id)
        {
            int length = this.json["products"].Count();
            string[] types = new string[length];

            List<Product> product = new List<Product>();

            foreach (var compo in this.json["products"])
            {
                if (id == (int)compo["id"])
                {
                    product.Add(new Product()
                    {
                        id = (string)compo["id"],
                        name = (string)compo["name"],
                        company = (string)compo["company"],
                        price = (string)compo["price"],
                        img = "Assets/" + (string)compo["img"],
                        type = (string)compo["type"],
                        config = (string)compo["config"]
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
}
