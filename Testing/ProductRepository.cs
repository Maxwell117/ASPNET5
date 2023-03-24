using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;
using Dapper;
using System.Data;
namespace Testing
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection conn)
        {
            _connection = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public Product GetProduct(int id)
        {
            return _connection.QuerySingle<Product>("SELECT * FROM products WHERE ProductID=@id;", new { id = id });
        }

   
         public void UpdateProduct(Product product)
         {
         _connection.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
         new { name = product.Name, price = product.Price, id = product.ProductID });
         }
     
    }
}
