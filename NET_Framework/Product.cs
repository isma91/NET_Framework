using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Windows.UI.Popups;
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

        /// <summary>
        /// NotifyPropertyChanged
        /// 
        /// Notify the client (xaml) that a property in the Product class change
        /// It's to get dinamycly the content of a specific type of Product without refresh the page
        /// 
        /// @param string; propertyName  the name of the property of the class Product
        /// 
        /// @return void;
        /// </summary>
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Product
        /// 
        /// The contructor of the class get the JSON file and parse him to get a full list of Product
        /// 
        /// @return void;
        /// </summary>
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
        
        /// <summary>
        /// get_all_type
        /// 
        /// Get all differents type of componants of the JSON
        /// 
        /// @return string[]; an array of all type of Product
        /// </summary>
        public string[] get_all_type()
        {
            int length = this.json["products"].Count();
            string[] types = new string[length];
            int count = 0;
            foreach (JToken product in this.json["products"])
            {
                types[count] = (string)product["type"];
                count++;
            }
            string[] all_types = types.Distinct().ToArray();
            return all_types;
        }

        /// <summary>
        /// getContent
        /// 
        /// Get the content of specific Product compared to what we want
        /// 
        /// @param string; config the config of the componant
        /// @param string; type the type of the componant
        /// 
        /// @return List<Product>; A list of Product who are in the type and config as asked
        /// </summary>
        public List<Product> getContent (string config, string type)
        {
            int length = this.json["products"].Count();
            string[] types = new string[length];

            List<Product> product = new List<Product>();

            foreach (JToken compo in this.json["products"])
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

        public int countOccurence(string source, string test)
        {
            int nb = 0;
            int i = 0;
            while ((i = source.IndexOf(test, i)) != -1)
            {
                i += test.Length;
                nb++;
            }
            return nb;
        }
        

        /*
         * save method
         * 
         * async method for saving id of item in a file json
         * 
         * @param int id
         * @return Task
         */
        public async Task save (string id, string type)
        {
            StorageFolder nameF = ApplicationData.Current.LocalFolder;
            StorageFolder createFolder = await nameF.CreateFolderAsync("config", CreationCollisionOption.OpenIfExists);
            StorageFile createFile = await createFolder.CreateFileAsync("config.xml", CreationCollisionOption.OpenIfExists);

            // create folder and open if exist
            StorageFolder getfolder = ApplicationData.Current.LocalFolder;
            StorageFolder getnewFolder = await getfolder.CreateFolderAsync("config", CreationCollisionOption.OpenIfExists);
            IReadOnlyList<StorageFile> getfiles = await getnewFolder.GetFilesAsync();

            // get file config.xml
            StorageFile desiredFile = getfiles.FirstOrDefault(x => x.Name == "config.xml");

            // read file
            string textContent = await FileIO.ReadTextAsync(desiredFile);


            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFolder newFolder = await folder.CreateFolderAsync("config", CreationCollisionOption.OpenIfExists);

            string occurence = "<" + type + ">";

            if (this.countOccurence(textContent, occurence) <= 0)
            {
                StorageFile textFile = await newFolder.CreateFileAsync("config.xml", CreationCollisionOption.OpenIfExists);
                await FileIO.WriteTextAsync(textFile, textContent + "\n<" + type.Replace(" ", "_") + ">" + id.ToString() + "</" + type.Replace(" ", "_") + ">");
            }

        }

        /// <summary>
        /// getContentById
        /// 
        /// Get the content of a Product by his own id
        /// 
        /// @param string; id the id of the componant
        /// 
        /// @return List<Product>; the Product
        /// </summary>
        public List<Product> getContentById (string id)
        {
            int length = this.json["products"].Count();
            string[] types = new string[length];

            List<Product> product = new List<Product>();

            foreach (JToken compo in this.json["products"])
            {
                if (id == (string)compo["id"])
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
                    return product;
                }
            }

            return product;
        }

        public class MyStuff
        {
            public string id { get; set; }
            public string name { get; set; }
            public string company { get; set; }
            public string price { get; set; }
            public string img { get; set; }
            public string type { get; set; }
            public string config { get; set; }
        }

        private void Quit(IUICommand command)
        {
            Windows.ApplicationModel.Core.CoreApplication.Exit();
        }
    }
}
