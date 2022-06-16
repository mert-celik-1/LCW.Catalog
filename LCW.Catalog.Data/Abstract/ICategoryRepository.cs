using LCW.Catalog.Core.Entities;
using LCW.Catalog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Data.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
