using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_Framework
{
    class Product
    {
        /*public string name;
        public string company;
        public string price;
        public string img;
        public string type;
        public string config;*/

        public Product()
        {
            string file_name = "stuffs.xml";
            string full_path =  System.IO.Path.GetFullPath(file_name);
            System.Xml.Linq.XDocument xml = System.Xml.Linq.XDocument.Load("stuffs.xml");
            System.Diagnostics.Debug.WriteLine(full_path);
            System.Diagnostics.Debug.WriteLine(xml);
        }

        /*public string Name
        {
            get;
            set;
        }
        public string Company
        {
            get;
            set;
        }
        public string Price
        {
            get;
            set;
        }
        public string Img
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }
        public string Config
        {
            get;
            set;
        }*/
    }
}
