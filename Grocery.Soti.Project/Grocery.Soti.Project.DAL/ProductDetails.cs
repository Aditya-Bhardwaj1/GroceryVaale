using Grocery.Soti.Project.DAL.Interfaces;
using Grocery.Soti.Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Grocery.Soti.Project.DAL
{
    public class ProductDetails : IProduct
    {
        private SqlConnection _connection = null;
        private SqlCommand _command = null;
        private SqlDataAdapter _adapter = null;
        private DataSet _dataset = null;
        private SqlDataReader _reader = null;

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (_connection = new SqlConnection(SqlConnectionString.GetConnectionString))
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
                                    Discontinued = Convert.ToBoolean(_reader.GetValue(5)),
                                    CategoryId = Convert.ToInt32(_reader.GetValue(6)),
                                    ProductImage = _reader.GetValue(9).ToString()
                                });
                            }
                        }
                    }
                }
            }
            return products;
        }

        public bool AddProduct(Product product)
        {
            using (_connection = new SqlConnection(SqlConnectionString.GetConnectionString))
            {
                using (_command = new SqlCommand("usp_AddProduct", _connection))
                {
                    _command.CommandType = System.Data.CommandType.StoredProcedure;

                    _command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    _command.Parameters.AddWithValue("@Description", product.Description);
                    _command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                    _command.Parameters.AddWithValue("@UnitsInStock", product.UnitsInStock);
                    _command.Parameters.AddWithValue("@Discontinued", product.Discontinued);
                    _command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                    _command.Parameters.AddWithValue("@ProductImage", product.ProductImage);

                    if (_connection.State == ConnectionState.Closed)
                    {
                        _connection.Open();
                    }

                    var result1 = _command.ExecuteNonQuery();

                    return result1 > 0;

                }
            }
        }

        public Product GetProductById(int productId)
        {
            using (_connection = new SqlConnection(SqlConnectionString.GetConnectionString))
            {
                using (_adapter = new SqlDataAdapter("select * from Products", _connection))
                {
                    using (_dataset = new DataSet())
                    {
                        _adapter.Fill(_dataset, "Products");

                        return _dataset.Tables["Products"].AsEnumerable().Select(x =>
                        new Product
                        {
                            ProductId = Convert.ToInt32(x.Field<int>("ProductId")),
                            ProductName = Convert.ToString(x.Field<string>("ProductName")),
                            Description = Convert.ToString(x.Field<string>("Description")),
                            UnitPrice = Convert.ToDecimal(x.Field<decimal>("UnitPrice")),
                            UnitsInStock = Convert.ToInt32(x.Field<int>("UnitsInStock")),
                            Discontinued = Convert.ToBoolean(x.Field<bool>("Discontinued")),
                            CategoryId = Convert.ToInt32(x.Field<int>("CategoryId")),
                            ProductImage = Convert.ToString(x.Field<string>("ProductImage"))
                        }).FirstOrDefault(p => p.ProductId == productId);
                    }
                }
            }
        }

        public List<Product> searchProduct(string productName, decimal? productPrice)
        {
            using (_connection = new SqlConnection(SqlConnectionString.GetConnectionString))
            {
                using (_adapter = new SqlDataAdapter("select * from Products", _connection))
                {
                    using (_dataset = new DataSet())
                    {
                        Regex regex = new Regex("");
                        if (productName != null)
                        {
                            regex = new Regex(productName.Trim());

                        }
                        if (productPrice == null)
                        {
                            productPrice = 0;
                        }
                        _ = new SqlCommandBuilder(_adapter);
                        _adapter.Fill(_dataset, "Products");

                        return _dataset.Tables["Products"].AsEnumerable().Select(x =>
                        new Product
                        {
                            ProductId = Convert.ToInt32(x.Field<int>("ProductId")),
                            ProductName = Convert.ToString(x.Field<string>("ProductName")),
                            Description = Convert.ToString(x.Field<string>("Description")),
                            UnitPrice = Convert.ToDecimal(x.Field<decimal>("UnitPrice")),
                            UnitsInStock = Convert.ToInt32(x.Field<int>("UnitsInStock")),
                            Discontinued = Convert.ToBoolean(x.Field<bool>("Discontinued")),
                            CategoryId = Convert.ToInt32(x.Field<int>("CategoryId")),
                            ProductImage = Convert.ToString(x.Field<string>("ProductImage"))
                        }).Where(p => (regex.IsMatch(p.ProductName)) && p.UnitPrice > productPrice).ToList();
                    }
                }
            }
        }
    }
}
