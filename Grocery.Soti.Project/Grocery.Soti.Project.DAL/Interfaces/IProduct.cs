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
        
        bool EditProduct(int productId, string productName, string description, decimal unitPrice, int unitInStock, bool discontinued, int categoryId);
        List<Product> GetAllProducts();
    }
}
