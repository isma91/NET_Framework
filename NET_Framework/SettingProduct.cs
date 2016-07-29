using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Storage;

namespace NET_Framework
{
    class SettingProduct : INotifyPropertyChanged
    {
        private string graphic_card;
        public string Graphic_card
        {
            get
            {
                return this.graphic_card;
            }
            set
            {
                this.graphic_card = value;
                NotifyPropertyChanged("Graphic_card");
            }
        }
        private string motherboard;
        public string Motherboard
        {
            get
            {
                return this.motherboard;
            }
            set
            {
                this.motherboard = value;
                NotifyPropertyChanged("Motherboard");
            }
        }
        private string processor;
        public string Processor
        {
            get
            {
                return this.processor;
            }
            set
            {
                this.graphic_card = value;
                NotifyPropertyChanged("Processor");
            }
        }
        private string disk;
        public string Disk
        {
            get
            {
                return this.disk;
            }
            set
            {
                this.disk = value;
                NotifyPropertyChanged("Disk");
            }
        }
        private string memory;
        public string Memory
        {
            get
            {
                return this.memory;
            }
            set
            {
                this.memory = value;
                NotifyPropertyChanged("Memory");
            }
        }

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
    }
}
