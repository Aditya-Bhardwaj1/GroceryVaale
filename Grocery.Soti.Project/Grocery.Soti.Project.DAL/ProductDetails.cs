using Grocery.Soti.Project.DAL.Interfaces;
using Grocery.Soti.Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Grocery.Soti.Project.DAL
{
    public class ProductDetails : IProduct
    {
        private SqlConnection _connection = null;
        private SqlDataAdapter _adapter = null;
        private DataSet _dataset = null;

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

        // search product by category Id

        public List<Product> ListProducts(int categoryId)
        {
            using (_connection = new SqlConnection(SqlConnectionString.GetConnectionString))
            {
                using (_adapter = new SqlDataAdapter("select * from Products ", _connection))
                {
                    using (_dataset = new DataSet())
                    {
                        _adapter.Fill(_dataset, "Products");

                        var product = _dataset.Tables["Products"].AsEnumerable()
                                     .Select(x => new Product
                                     {
                                         ProductName = x.Field<string>("ProductName"),
                                         Description = x.Field<string>("Description"),
                                         UnitPrice = x.Field<decimal>("UnitPrice"),
                                         UnitsInStock = x.Field<int>("UnitsInStock"),
                                         CategoryId = x.Field<int>("CategoryId"),
                                     }).Where(x => x.CategoryId == categoryId).ToList();

                        return product;

                    }
                }

            }

        }
    }
}
