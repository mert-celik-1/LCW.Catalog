using LCW.Catalog.Core.Entities;
using LCW.Catalog.Core.Repositories;
using LCW.Catalog.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Data.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
        private AppDbContext AppDbContext
        {
            get { return _context as AppDbContext; }
        }

        //public async Task<Category> GetById(string categoryId)
        //{
        //    return await AppDbContext.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);
        //}
    }
}
