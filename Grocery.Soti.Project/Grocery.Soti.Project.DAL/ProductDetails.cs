using Grocery.Soti.Project.DAL.Interfaces;
using Grocery.Soti.Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Soti.Project.DAL
{
    public class ProductDetails : IProduct
    {
        private SqlConnection _connection = null;
        private SqlDataAdapter _adapter = null;
        private DataTable _dt = null;
        private DataSet _dataset = null;
        private SqlCommand _command = null;
        private SqlDataReader _reader = null;

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

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (_connection = new SqlConnection(SqlConnectionString.GetConnectionString))
            {
                using (_command = new SqlCommand("Select * from Products", _connection))
                {
                    if (_connection.State != ConnectionState.Open)
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
                                    CreatedDate = Convert.ToDateTime(_reader.GetValue(7)),
                                   // ModifiedDate=Convert.ToDateTime(_reader?.GetValue(8)),
                                    ProductImage = _reader.GetValue(9).ToString()
                                });
                            }
                        }
                    }
                }
            }
            return products;
        }
        public bool EditProduct(int productId, string productName, string description, decimal unitPrice, int unitInStock, bool discontinued, int categoryId, string productImageUrl)
        {
            using (_connection = new SqlConnection(SqlConnectionString.GetConnectionString))
            {
                using (_adapter = new SqlDataAdapter("usp_UpdateProduct", _connection))
                {
                    _adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    _adapter.SelectCommand.Parameters.AddWithValue("@ProductId", productId);
                    _adapter.SelectCommand.Parameters.AddWithValue("@ProductName", productName);
                    _adapter.SelectCommand.Parameters.AddWithValue("@Description", description);
                    _adapter.SelectCommand.Parameters.AddWithValue("@UnitPrice", unitPrice);
                    _adapter.SelectCommand.Parameters.AddWithValue("@UnitInStock", unitInStock);
                    _adapter.SelectCommand.Parameters.AddWithValue("@Discontinued", discontinued);
                    _adapter.SelectCommand.Parameters.AddWithValue("@CategoryId", categoryId);
                    _adapter.SelectCommand.Parameters.AddWithValue("@ProductImage", productImageUrl);


                    SqlParameter param = new SqlParameter("@return", SqlDbType.Int);
                    param.Direction = ParameterDirection.ReturnValue;
                    _adapter.SelectCommand.Parameters.Add(param);
                    using (_dt = new DataTable())
                    {
                        _adapter.Fill(_dt);
                        return Convert.ToInt32(param.Value) > 0;
                    }

                }

            }
        }

    }
}