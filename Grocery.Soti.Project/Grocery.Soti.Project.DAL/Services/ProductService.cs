using Grocery.Soti.Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using Grocery.Soti.Project.DAL.Interfaces;

namespace Grocery.Soti.Project.DAL
{
    public class ProductService : IProduct
    {
        private SqlConnection _connection = null;
        private SqlCommand _command = null;
        private SqlDataReader _reader = null;

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (_connection = new SqlConnection(SqlConnectionStrings.GetConnectionString))
            {
                using (_command = new SqlCommand("Select * from Products", _connection))
                {
                    if (_connection.State != System.Data.ConnectionState.Open)
                    {
                        _connection.Open();
                    }
                    using (_reader = _command.ExecuteReader())
                    {
                        if (_reader.HasRows)
                        {
                            while (_reader.Read())
                            {
                                products.Add(new Product
                                {
                                    ProductId = Convert.ToInt32(_reader.GetValue(0)),
                                    ProductName = _reader.GetValue(1).ToString(),
                                    Description = _reader.GetValue(2).ToString(),
                                    UnitPrice = Convert.ToDecimal(_reader.GetValue(3)),
                                    UnitsInStock = Convert.ToInt32(_reader.GetValue(4)),
                                    Discontinued = Convert.ToInt16(_reader.GetValue(5)),
                                    CategoryId = Convert.ToInt32(_reader.GetValue(6)),
                                    ProductImage = _reader.GetValue(7).ToString()
                                });
                            }
                        }
                    }
                }
            }
            return products;
        }

        
    }
}
