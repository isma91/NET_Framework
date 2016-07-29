using System.Collections.Generic;
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

        /// <summary>
        /// addInList
        /// 
        /// Get a List<Product> to add every Product class in the ObservableCollection<Product>
        /// 
        /// @param List<Product>; list  the list of Product
        /// 
        /// @return void;
        /// </summary>
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
