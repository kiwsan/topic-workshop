using System.Web.Mvc;
using Application.Models.Requests;
using Data.Entities;
using Data.Repositories;
using Data.Utils;

namespace WebMvc.Controllers
{
    public class AuthorizationController : BaseController
    {
        // GET
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string username, string password)
        {
            using (var userRepo = new UserRepository())
            {
                Session[AppConstants.AuthKey] = userRepo.SignIn(username, password);
            }

            return IsExpire ? RedirectToAction("SignIn") : RedirectToRoute("Topic");
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUpRequest command)
        {
            //add a new user
            using (var userRepo = new UserRepository())
            {
                if (userRepo.IsExisted(command.Email, command.UserName))
                {
                    return View();
                }

                //transfer object 

                userRepo.Add(new User
                {
                    Email = command.Email,
                    UserName = command.UserName,
                    Password = command.Password,
                    DisplayName = command.DisplayName
                });
            }

            return RedirectToAction("SignIn");
        }
    }
}