using IceCreamShopTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamShopTwo.Services
{
    public interface IDAL
    {
        public int CreateProduct(Product product);
        public int DeleteProductById(int id);
        public IEnumerable<Product> GetCategories();
        public IEnumerable<Product> GetProductsInCategory(string cat);
        public IEnumerable<Product> GetAllProducts();
        public Product GetProductById(int id);
        public int UpdateProductBy(Product product);
    }
}
