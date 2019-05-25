using System.Web.Mvc;
using System.Web.Mvc.Filters;
using Data.Utils;

namespace WebMvc.Filters
{
    public class AuthAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.HttpContext.Session[AppConstants.AuthKey] == null)
            {
                filterContext.Result = new RedirectResult("Authorization/SignIn");
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
}