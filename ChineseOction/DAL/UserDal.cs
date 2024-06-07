using ChineseOction.Models;
using Microsoft.EntityFrameworkCore;

namespace ChineseOction.DAL
{
    public class UserDal : IUserDal
    {
        private readonly ChinesesOctionContext chinesesOctionContext;

        public UserDal(ChinesesOctionContext chinesesOctionContext)
        {
            this.chinesesOctionContext = chinesesOctionContext;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await chinesesOctionContext.Users.ToListAsync();
        }
    }
}
