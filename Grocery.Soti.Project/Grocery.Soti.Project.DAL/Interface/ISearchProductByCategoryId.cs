using SOTI.DAL.DEMO.SEARCH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOTI.DAL.DEMO.SEARCH.Interface
{
    public interface ISearchProductByCategoryId
    {
       // object GetProduct();

        List<Product> SearchProductByCategoryId(int CategoryId);
    }
}
