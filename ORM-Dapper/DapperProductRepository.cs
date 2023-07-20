using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dapper;

namespace ORM_Dapper
{
    internal class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Products> GetAllProducts()
        {
            return _connection.Query<Products>("SELECT * FROM PRODUCTS;");
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name, Price, CategoryID) VALUES (@prodName, @prodPrice, @catID);",
             new { prodName = name , prodPrice = price, catID = categoryID});
        }

        public void UpdateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("UPDATE PRODUCTS SET Price = @prodPrice, CategoryID = @catID WHERE Products.Name = @prodName",
             new { prodName = name, prodPrice = price, catID = categoryID });
        }

        public void RemoveProduct(string name)
        {
            _connection.Execute("DELETE FROM PRODUCTS WHERE products.Name = @prodName",
                new { prodName = name });
        }
    }
}
