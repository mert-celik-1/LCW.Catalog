using LCW.Catalog.Core.Dtos.OfferDtos;
using LCW.Catalog.Core.Entities;
using LCW.Catalog.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Services.Abstract
{
    public interface IOfferService
    {
        Task<NoDataResponse> MakeAnOffer(OfferDto offerDto);
        Task<NoDataResponse> Buy(OfferDto offerDto);
        Task<Boolean> IsAlreadyOffered(OfferDto offerDto);
        Task<NoDataResponse> WithdrawOffer(string productId,string userId);
        Task<Response<List<Offer>>> GetUserOffers(string userId);
        Task<Response<List<Offer>>> GetProductOffers(string productId);


    }
}
