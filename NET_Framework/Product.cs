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
using System.Xml;

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
        public async Task save (int id, string type)
        {
            // create folder and open if exist
            var getfolder = ApplicationData.Current.LocalFolder;
            var getnewFolder = await getfolder.CreateFolderAsync("config", CreationCollisionOption.OpenIfExists);
            var getfiles = await getnewFolder.GetFilesAsync();

            // get file config.xml
            var desiredFile = getfiles.FirstOrDefault(x => x.Name == "config.xml");

            // read file
            var textContent = await FileIO.ReadTextAsync(desiredFile);


            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
            var folder = ApplicationData.Current.LocalFolder;
            var newFolder = await folder.CreateFolderAsync("config", CreationCollisionOption.OpenIfExists);

            string occurence = "<" + type + ">";

            if (this.countOccurence(textContent, occurence) <= 0)
            {
                var textFile = await newFolder.CreateFileAsync("config.xml", CreationCollisionOption.OpenIfExists);
                await FileIO.WriteTextAsync(textFile, textContent + "\n<" + type + ">" + id.ToString() + "</" + type + ">");
            }

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
            var getfolder = ApplicationData.Current.LocalFolder;
            var getnewFolder = await getfolder.CreateFolderAsync("config", CreationCollisionOption.OpenIfExists);
            var getfiles = await getnewFolder.GetFilesAsync();

            var desiredFile = getfiles.FirstOrDefault(x => x.Name == "config.xml");
            string textContent = await FileIO.ReadTextAsync(desiredFile);

            List<MyStuff> product = new List<MyStuff>();

            XmlReader xReader = XmlReader.Create(new StringReader(textContent));
            while (xReader.Read())
            {
                Debug.WriteLine(xReader.Name);
                Debug.WriteLine(xReader.Value);
                string type = xReader.Name; // graphic card
                string id = xReader.Value; // id

                var stuff = getContentById(id);
                product.Add(new MyStuff()
                    {
                        id = (string)stuff[0].id,
                        name = (string)stuff[0].name,
                        company = (string)stuff[0].company,
                        price = (string)stuff[0].price,
                        img = "Assets/" + (string)stuff[0].img,
                        type = (string)stuff[0].type,
                        config = (string)stuff[0].config
                    });
            }


            Debug.WriteLine(product);
        }

        /*
         * getContentById method
         * 
         * @param int id
         * @return List<Product>
         */
        public List<Product> getContentById (string id)
        {
            int length = this.json["products"].Count();
            string[] types = new string[length];

            List<Product> product = new List<Product>();

            foreach (var compo in this.json["products"])
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
                }
            }

            return product;
        }

        private void Quit(IUICommand command)
        {
            Windows.ApplicationModel.Core.CoreApplication.Exit();
        }
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
}
