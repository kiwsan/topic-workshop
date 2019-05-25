using System.Web.Mvc;
using Application.Models.Requests;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Data.Utils;

namespace WebMvc.Controllers
{
    public class AuthorizationController : BaseController
    {
        private readonly IUserRepository _userRepository;

        public AuthorizationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string username, string password)
        {
            var user = _userRepository.SignIn(username, password);

            Session[AppConstants.AuthKey] = user;

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
            if (!ModelState.IsValid)
            {
                return View();
            }

            //add a new user
            if (_userRepository.IsExisted(command.Email, command.UserName))
            {
                return View();
            }

            //transfer object 
            _userRepository.Add(new User
            {
                Email = command.Email,
                UserName = command.UserName,
                Password = command.Password,
                DisplayName = command.DisplayName
            });

            return RedirectToAction("SignIn");
        }
    }
}