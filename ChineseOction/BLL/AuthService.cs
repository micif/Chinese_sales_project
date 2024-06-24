using ChineseOction.DAL;
using ChineseOction.Models;
using ChineseOction.Models.DTO;

namespace ChineseOction.BLL
{
    public class AuthService : IAuthService

    {
        private readonly IAuthDal userDal;

        public AuthService(IAuthDal userDal)
        {
            this.userDal = userDal;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await userDal.GetAllUsers();
        }
        public async Task<string> Login(LoginDto loginDto)
        {
            return await userDal.Login(loginDto);
        }
    }
}
