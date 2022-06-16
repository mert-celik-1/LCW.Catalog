using LCW.Catalog.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Data.Concrete
{
    public class UnitOfWork:IUnitOfWork
    {
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;
        private OfferRepository _offerRepository;
        private UserRefreshTokenRepository _userRefreshTokenRepository;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }



        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_context);
        public IOfferRepository Offers => _offerRepository ?? new OfferRepository(_context);

        public IUserRefreshTokenRepository RefreshTokens => _userRefreshTokenRepository ?? new UserRefreshTokenRepository(_context);

        public IProductRepository Products => _productRepository ?? new ProductRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
