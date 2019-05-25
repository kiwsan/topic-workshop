using System.Web.Mvc;
using Data.Entities;
using Data.Utils;

namespace WebMvc.Controllers
{
    public abstract class BaseController : Controller
    {
        protected bool IsExpire => Session[AppConstants.AuthKey] == null;

        protected void SignOut()
        {
            Session[AppConstants.AuthKey] = null;
        }

        protected User CurrentUser => (User) Session[AppConstants.AuthKey];
    }
}