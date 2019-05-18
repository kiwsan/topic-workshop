using System.Web.Mvc;
using Topic.Data.Repositories;
using Topic.Models;

namespace Topic.Controllers
{
    public class AuthController : ControllerBase
    {
        // GET
        [HttpGet]
        public ActionResult SignIn(string username, string password)
        {
            UserSignIn(username, password);

            if (Me == null)
            {
                return RedirectToAction("SignIn");
            }

            return RedirectToRoute("Topic");
        }

        [HttpGet]
        public ActionResult SignUp(User command)
        {
            //add a new user
            using (var userRepo = new UserRepository())
            {
                if (userRepo.IsExisted(command.Email, command.UserName))
                {
                    return View();
                }

                userRepo.Add(command);
            }

            return RedirectToAction("SignIn");
        }
    }
}