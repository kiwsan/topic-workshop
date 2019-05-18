using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Topic.Models;
using Topic.Utils;

namespace Topic.Data.Repositories
{
    public class UserRepository : IDisposable
    {
        private readonly DbContext _context;

        public UserRepository()
        {
            _context = new DbContext(AppConstants.ConnectionString);
        }

        public User Add(User user)
        {
            _context.ExecuteProc<object>("uspAdd",
                new SqlParameter("@username", user.UserName),
                new SqlParameter("@password", user.Password),
                new SqlParameter("@email", user.Email),
                new SqlParameter("@displayName", user.DisplayName)
            );

            return user;
        }

        public User FindById(int id)
            => _context.ExecuteProc<User>("uspFindById", new SqlParameter("@id", id)).FirstOrDefault();

        public User SignIn(string username, string password)
            => _context.ExecuteProc<User>("uspSignIn",
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)).FirstOrDefault();

        public User SignUp(User user)
        {
            _context.ExecuteProc<object>("uspSignUp",
                new SqlParameter("@username", user.UserName),
                new SqlParameter("@password", user.Password),
                new SqlParameter("@displayName", user.DisplayName),
                new SqlParameter("@email", user.Email));

            return user;
        }
        
        public bool IsExisted(string email, string username)
            => _context.ExecuteProc<User>("uspIsExisted", new SqlParameter("@email", email),
                   new SqlParameter("@username", username)).FirstOrDefault() != null;

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}