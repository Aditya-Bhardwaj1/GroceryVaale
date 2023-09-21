using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Soti.Project.DAL.Interfaces
{
    public interface ICategories
    {
        bool InsertCategory(string categoryName, string categoryImgUrl);
    }
}
