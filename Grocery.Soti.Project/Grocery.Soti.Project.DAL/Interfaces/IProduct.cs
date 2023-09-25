using Grocery.Soti.Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Soti.Project.DAL.Interfaces
{
    public interface IProduct
    {
        List<Product> GetAllProducts();

        bool AddProduct(Product product);

        Product GetProductById(int productId);

        List<Product> searchProduct(string productName, decimal? productPrice);
    }
}
