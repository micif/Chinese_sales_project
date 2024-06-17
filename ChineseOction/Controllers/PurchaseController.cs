using AutoMapper;
using ChineseOction.BLL;
using ChineseOction.DAL;
using ChineseOction.Models;
using ChineseOction.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ChineseOction.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {

        private readonly IPurchaseService purchaseService;
        private readonly IMapper mapper;
        public PurchaseController(IPurchaseService purchaseService, IMapper mapper)
        {
            this.purchaseService = purchaseService;
            this.mapper = mapper;

        }

        [HttpGet("GetDetails")]
        public async Task<List<User>> GetDetails()
        {
            return await purchaseService.GetDetails();
        }
        [HttpGet("GetPurchaseByGift/{giftId}")]

        public async Task<List<PurchaseList>> GetPurchaseByGift(int giftId)
        {
            return await purchaseService.GetPurchaseByGift(giftId);
        }
        [HttpGet("SortByMaxPrice")]

        public async Task<List<PurchaseList>> SortByMaxPrice()
        {
            return await purchaseService.SortByMaxPrice();
        }
        [HttpGet("SortByMostPurchasedGift")]

        public async Task<List<PurchaseList>> SortByMostPurchasedGift()
        {
            return await purchaseService.SortByMostPurchasedGift();

        }
        [HttpPost("{userId}")]
        public async Task<Purchase> PlaceOrder(int userId)
        {
            return await purchaseService.PlaceOrder(userId);
        }



    }
}



