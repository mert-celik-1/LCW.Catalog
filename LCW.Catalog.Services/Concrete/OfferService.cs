using AutoMapper;
using LCW.Catalog.Core.Dtos.OfferDtos;
using LCW.Catalog.Core.Entities;
using LCW.Catalog.Data.Abstract;
using LCW.Catalog.Services.Abstract;
using LCW.Catalog.Shared.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Services.Concrete
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;


        public OfferService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<NoDataResponse> Buy(OfferDto offerDto)
        {
            Offer offer = new Offer
            {
                Name="Buy",
                CreatedDate = DateTime.UtcNow,
                Id = Guid.NewGuid().ToString(),
                OfferedPrice = offerDto.OfferedPrice,
                ProductId = offerDto.ProductId,
                UserId = offerDto.UserId
            };

            var product = await _unitOfWork.Products.GetAsync(x => x.Id == offerDto.ProductId);

            product.IsSold = true;

            await _unitOfWork.Products.UpdateAsync(product);

            await _unitOfWork.Offers.AddAsync(offer);

            await _unitOfWork.CommitAsync();

            return new NoDataResponse(ResultStatus.Success, "Ürün satın alındı");

        }

        public async Task<NoDataResponse> MakeAnOffer(OfferDto offerDto)
        {

            var isAlreadyOffered = await this.IsAlreadyOffered(offerDto);

            if (isAlreadyOffered)
            {
                return new NoDataResponse(ResultStatus.Error, "Bu ürüne daha önceden teklif yapılmış");
            }

            Offer offer = new Offer
            {
                Name="Offer",
                CreatedDate = DateTime.UtcNow,
                Id = Guid.NewGuid().ToString(),
                OfferedPrice = offerDto.OfferedPrice,
                ProductId = offerDto.ProductId,
                UserId = offerDto.UserId
            };

            await _unitOfWork.Offers.AddAsync(offer);

            await _unitOfWork.CommitAsync();

            return new NoDataResponse(ResultStatus.Success,"Teklif başarıyla yapıldı");
            
        }

        public async Task<NoDataResponse> WithdrawOffer(string productId, string userId)
        {

            var offer = await _unitOfWork.Offers.GetAsync(x => x.ProductId == productId && x.UserId == userId);

            await _unitOfWork.Offers.DeleteAsync(offer);

            await _unitOfWork.CommitAsync();

            return new NoDataResponse(ResultStatus.Success,"Teklif geri çekildi");

        }

        public async Task<Response<List<Offer>>> GetUserOffers(string userId)
        {

            var offers = await _unitOfWork.Offers.GetAllAsync(x => x.UserId == userId);

            return new Response<List<Offer>>(ResultStatus.Success, (List<Offer>)offers);

        }
        public async Task<Response<List<Offer>>> GetProductOffers(string productId)
        {

            var offers = await _unitOfWork.Offers.GetAllAsync(x => x.ProductId == productId);

            return new Response<List<Offer>>(ResultStatus.Success, (List<Offer>)offers);

        }


        public async Task<Boolean> IsAlreadyOffered(OfferDto offerDto)
        {
            var offer = await _unitOfWork.Offers.GetAllAsync(x => x.ProductId == offerDto.ProductId && x.UserId==offerDto.UserId);

            if (offer.Count==0)
            {
                return false;

            }

            return true;

        }


    }
}
