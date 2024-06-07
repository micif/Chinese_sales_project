using ChineseOction.Models;

namespace ChineseOction.DAL
{
    public interface IUserDal
    {
        Task<List<User>> GetAllUsers();
    }
}