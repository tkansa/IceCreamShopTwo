using Dapper;
using IceCreamShopTwo.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamShopTwo.Services

{
    public class DALSqlServer : IDAL
    {

        SqlConnection connection;

        public DALSqlServer(IConfiguration config)
        {
            string connectionString = config.GetConnectionString("default");
            connection = new SqlConnection(connectionString);
        }

        public int CreateProduct(Product product)
        {
            string addString = "INSERT INTO Products (Name, Category, Description, Price)";
            addString += "VALUES (@Name, @Category, @Description, @Price)";
            int result = connection.Execute(addString, product);
            return result;
        }

        public int DeleteProductById(int id)
        {
            string deleteString = "DELETE from Products WHERE Id=@val";
            int result = connection.Execute(deleteString, new { val = id });
            return result;
        }


        public IEnumerable<Product> GetCategories()
        {
            string queryString = "SELECT DISTINCT Category from Products";
            IEnumerable<Product> products = connection.Query<Product>(queryString);

            return products;
        }

        public IEnumerable<Product> GetProductsInCategory(string cat)
        {
            string queryString = "SELECT * FROM Products WHERE Category=@category";
            IEnumerable<Product> products = connection.Query<Product>(queryString, new { category = cat });
            return products;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            string queryString = "SELECT * from Products";
            IEnumerable<Product> products = connection.Query<Product>(queryString);
            return products;
        }

        public Product GetProductById(int id)
        {
            string queryString = "SELECT * FROM Products WHERE Id=@val";
            Product product = connection.QueryFirst<Product>(queryString, new { val = id });
            return product;
        }

        public int UpdateProductBy(Product product)
        {
            string editString = "UPDATE Products SET Name=@Name, Description = @Description, Category=@Category, Price=@Price WHERE Id=@Id";

            int result = connection.Execute(editString, product);
            return result;
        }
    }
}
