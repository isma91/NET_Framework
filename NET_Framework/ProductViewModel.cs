﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET_Framework
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Product> productList = new ObservableCollection<Product>();
        public ObservableCollection<Product> ProductList
        {
            get
            {
                return this.productList;
            }

            set
            {
                this.NotifyPropertyChanged("ProductList");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void addInList(List<Product> list)
        {
            this.productList.Clear();
            foreach (var product in list)
            {
                this.productList.Add(product);
            }
        }

        private void NotifyPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}