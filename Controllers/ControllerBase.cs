using System.Web.Mvc;
using Topic.Data.Repositories;
using Topic.Models;

namespace Topic.Controllers
{
    public class ControllerBase : Controller
    {
        public User Me
            => (User) Session["user"];

        protected void SignIn(string username, string password)
        {
            using (var userRepo = new UserRepository())
            {
                Session["user"] = userRepo.SignIn(username, password);
            }
        }

        protected void SignOut()
        {
            Session["user"] = null;
        }

        protected bool IsExpire
            => (User) Session["user"] == null;
    }
}