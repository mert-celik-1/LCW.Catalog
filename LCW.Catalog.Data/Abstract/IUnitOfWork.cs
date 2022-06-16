using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Data.Abstract
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IOfferRepository Offers { get; }
        IUserRefreshTokenRepository RefreshTokens { get; }

        Task CommitAsync();

        void Commit();
    }
}
