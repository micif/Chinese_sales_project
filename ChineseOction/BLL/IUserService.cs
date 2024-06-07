using ChineseOction.Models;

namespace ChineseOction.BLL
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
    }
}