using ChineseOction.BLL;
using ChineseOction.DAL;
using ChineseOction.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChineseOction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<List<User>> GetAllUsers()
        {
            return await userService.GetAllUsers();
        }



    }
}
