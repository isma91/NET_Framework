﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NET_Framework
{
    public class ProductViewModel
    {
        private ObservableCollection<Product> productList = new ObservableCollection<Product>();
        public ObservableCollection<Product> ProductList
        {
            get
            {
                return productList;
            }
        }

        public void addInList(List<Product> list)
        {
            this.productList.Clear();
            foreach (Product product in list)
            {
                this.productList.Add(product);
            }
        }
    }
}
