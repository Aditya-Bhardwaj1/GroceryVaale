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
        public bool EditProduct(int productId, string productName, string description, decimal unitPrice, int unitInStock, bool discontinued, int categoryId)
        {
            using (_connection = new SqlConnection(SqlConnectionStrings.GetConnectionString))
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
