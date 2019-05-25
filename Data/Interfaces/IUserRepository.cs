using Data.Entities;

namespace Data.Interfaces
{
    public interface IUserRepository
    {
        User Add(User user);
        User FindById(int id);
        User SignIn(string username, string password);
        User SignUp(User user);
        bool IsExisted(string email, string username);
    }
}