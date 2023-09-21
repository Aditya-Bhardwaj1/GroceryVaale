using SOTI.DAL.DEMO.SEARCH.Interface;
using SOTI.DAL.DEMO.SEARCH.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOTI.DAL.DEMO.SEARCH
{
    public class SearchProductByCategory : ISearchProductByCategoryId
    {
        private SqlConnection _connection = null;

        private SqlDataAdapter _adapter = null;

        private DataSet _ds = null;

        /// <summary>
        /// Searching Product by category Id
        /// </summary>
        /// <returns> Return Product Table</returns>
        public List<Product> SearchProductByCategoryId(int categoryId)
        {
            using (_connection = new SqlConnection(SqlConnectionString.GetConnectionString()))
            {
                using (_adapter = new SqlDataAdapter("select * from Products ", _connection))
                {
                    using (_ds = new DataSet())
                    {
                        _adapter.Fill(_ds, "Products");

                        var product = _ds.Tables["Products"].AsEnumerable()
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

