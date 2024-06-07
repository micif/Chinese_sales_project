using ChineseOction.DAL;
using ChineseOction.Models;

namespace ChineseOction.BLL
{
    public class UserService : IUserService

    {
         private readonly IUserDal userDal;

        public UserService(IUserDal userDal)
        {
            this.userDal = userDal;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await userDal.GetAllUsers  ();
        }
    }
}
