using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AquaHobby.Api.Controllers
{
    public class BaseController : ApiController
    {
        protected ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        protected async Task<string> GetCurrentId()
        {
            var _user = await UserManager.FindByNameAsync(User.Identity.Name);
            return _user == null ? "" : _user.Id;
        }
    }
}
