﻿using Grocery.Soti.Project.DAL.Interfaces;
using Grocery.Soti.Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Soti.Project.DAL
{
    public class CategoryDetails :ICategory
    {
        private SqlConnection _connection = null;
        private SqlDataAdapter _adapter = null;
        private DataTable _dt = null;

        public List<Category> GetAllCategories()
        {
            using (_connection = new SqlConnection(SqlConnectionString.GetConnectionString))
            {
                using (_adapter = new SqlDataAdapter("Select * from Categories", _connection))
                {
                    using (DataSet _ds = new DataSet())
                    {
                        _adapter.Fill(_ds, "Categories");
                        var categories = _ds.Tables["Categories"].AsEnumerable().Select(x => new Category
                        {
                            CategoryId = x.Field<int>("CategoryId"),
                            CategoryName = x.Field<string>("CategoryName"),
                            CategoryImageUrl = x.Field<string>("CategoryImage"),

                        }).ToList();

                        return categories;
                    }
                }
            }
        }

        public bool InsertCategory(string categoryName, string categoryImgUrl)
        {
            using (_connection = new SqlConnection(SqlConnectionString.GetConnectionString))
            {
                using (_adapter = new SqlDataAdapter("usp_AddCategory", _connection))
                {
                    _adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    _adapter.SelectCommand.Parameters.AddWithValue("@CategoryName", categoryName);
                    _adapter.SelectCommand.Parameters.AddWithValue("@CategoryImgUrl", categoryImgUrl);

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
