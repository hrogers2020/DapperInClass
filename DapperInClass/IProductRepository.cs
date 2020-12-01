﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DapperInClass
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        void CreateProduct(string name, double price, int categoryID);
    }
}
