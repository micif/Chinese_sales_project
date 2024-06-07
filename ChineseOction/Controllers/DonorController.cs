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
    public class DonorController :ControllerBase
    {

        private readonly IDonorService donatesService;
        private readonly IMapper mapper;
        public DonorController(IDonorService donatesService, IMapper mapper)
        {
            this.donatesService = donatesService;
            this.mapper = mapper;

        }

        [HttpGet]
        public async Task<List<Donor>> Get()
        {
            return await donatesService.Get();
        }
        [HttpPost]
        public async Task<ActionResult<Donor>> Add(DonorDto donorDto)
        {
            var donor = mapper.Map<Donor>(donorDto);
            
            return await donatesService.Add(donor);
        }
        [HttpDelete("{id}")]
        public async Task Remove(int id)
        {
            await donatesService.Remove(id);
        }

        [HttpPut]
        public async Task<Donor> Update(UpdateDonorDto donorDto)
        {
            var donor = mapper.Map<Donor>(donorDto);
            return await donatesService.Update(donor);
        }
        [HttpGet("SearchByName{name}")]
        public async Task<List<Donor>> SearchByName(string name)
        {
            return await donatesService.SearchByName(name);
        }
        [HttpGet("SearchByEmail{email}")]

        public async Task<List<Donor>> SearchByEmail(string email)
        {
            return await donatesService.SearchByEmail(email);
        }
        [HttpGet("SearchByGift{giftId}")]

        public async Task<List<Donor>> SearchByGift(int giftId)
        {
            return await donatesService.SearchByGift(giftId);
        }

    }
}
