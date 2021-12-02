using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11._3_CoffeeShop.Models
{
    public class DAL
    {
        SqlConnection connection;

        public DAL(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public IEnumerable<Product> GetProductCategory()
        {
            string queryString = "SELECT DISTINCT Category FROM Products";
            IEnumerable<Product> Products = connection.Query<Product>(queryString);

            return Products;
        }

        public IEnumerable<Product> GetProductsAll()
        {
            string queryString = "SELECT * FROM Products";
            IEnumerable<Product> Products = connection.Query<Product>(queryString);

            return Products;
        }
        public Product GetProductById(int id)
        {
            string queryString = "SELECT * FROM Products WHERE Id = @val";
            Product product = connection.QueryFirstOrDefault<Product>(queryString, new { val = id });

            return product;
        }

        public IEnumerable<Product> GetProductsInCategory(string category)
        {
            string queryString = "SELECT * FROM Products WHERE Category = @val";
            IEnumerable<Product> Products = connection.Query<Product>(queryString, new { val = category });

            return Products;
        }

        public int CreateProduct(Product product)
        {
            string addString = "INSERT INTO Products (Name, Price, Description, Category) ";
            addString += "VALUES (@Name, @Price, @Description, @Category)";
            return connection.Execute(addString, product);
        }

        public int DeleteProductById(int id)
        {
            string deleteString = "DELETE FROM Products WHERE Id = @val";
            return connection.Execute(deleteString, new { val = id });
        }

        public int UpdateProductById(Product product)
        {
            string editString = "UPDATE Products SET Name = @Name, Price = @Price, Description = @Description, ";
            editString += "Category = @Category WHERE Id = @Id";
            return connection.Execute(editString, product);
        }
    }
}