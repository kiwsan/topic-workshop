using System.Web.Mvc;
using Data.Entities;
using Data.Utils;

namespace WebMvc.Controllers
{
    public abstract class BaseController : Controller
    {
        protected bool IsExpire
        {
            get { return Session[AppConstants.AuthKey] == null; }
        }

        protected void SignOut()
        {
            Session[AppConstants.AuthKey] = null;
        }

        protected User Auth
        {
            get { return (User) Session[AppConstants.AuthKey]; }
        }
    }
}