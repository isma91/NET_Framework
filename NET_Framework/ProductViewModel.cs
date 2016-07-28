using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_Framework
{
    public class ProductViewModel
    {
        private ObservableCollection<Product> productList = new ObservableCollection<Product>();
        public ObservableCollection<Product> ProductList { get { return this.productList; } }

        public void addInList(List<Product> list)
        {
            this.productList.Clear();
            foreach (var product in list)
            {
                this.productList.Add(product);
            }
        }
    }
}
