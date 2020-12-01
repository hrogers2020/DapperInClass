using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;

namespace DapperInClass
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;");
        }

        public void CreateProduct(string newProductName, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name, Price, CategoryID) VALUES (@productName, @productPrice, @productCategoryID);",
                new { productName = newProductName, productPrice = price, productCategoryID = categoryID  });
        }

    }
}
