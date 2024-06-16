using AutoMapper;
using ChineseOction.BLL;
using ChineseOction.Models.DTO;
using ChineseOction.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChineseOction.Controllers
{       [ApiController]
        [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
    
        private readonly ICartService cartService;
        private readonly IMapper mapper;
        public CartController(ICartService cartService, IMapper mapper)
        {
            this.cartService = cartService;
            this.mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<List<Cart>> GetCart(int userId)
        {
            return await cartService.GetCart(userId);
        }
        [HttpPost("{userId}/{giftId}/{quantity}")]
        public async Task<ActionResult<int>> AddToCart( int userId, int giftId, int quantity)
        {
            return await cartService.AddToCart(userId,giftId,quantity);
        }
        [HttpPut("Increas/{userId}/{giftId}")]

        public async Task<ActionResult<int>> Increas(int userId, int giftId)
        {
            return await cartService.Increas(userId, giftId);
        }
        [HttpPut("Reduce/{userId}/{giftId}")]

        public async Task<ActionResult<int>> Reduce(int userId, int giftId)
        {
            return await cartService.Reduce(userId, giftId);
        }
        [HttpDelete("{userId}/{giftId}")]

        public async Task<ActionResult<int>> RemoveFromCart(int userId, int giftId)
        {
            return await cartService.RemoveFromCart(userId, giftId);
        }
    }
}
