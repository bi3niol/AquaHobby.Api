using AquaHobby.DAL.Services;
using AquaHobby.Models;
using AquaHobby.Models.Photos;
using AquaHobby.Models.User;
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
    [Authorize]
    public class UsersController : BaseController
    {
        private IAppUserService UserService;

        public UsersController(IAppUserService userService)
        {
            UserService = userService;
        }

        [HttpGet]
        [ActionName("Galleries")]
        public async Task<Gallery[]> GetGalleries(string id)
        {
            return await UserService.GetUserGalleriesAsync(id);
        }

        [HttpGet]
        [ActionName("Aquariums")]
        public async Task<Aquarium[]> GetAquariums(string id)
        {
            return await UserService.GetUserAquariumsAsync(id);
        }

        [HttpGet]
        [ActionName("user")]
        public async Task<AppUser> GetUser(string id)
        {
            var user = await UserService.GetUserWithProperiesAsync(id);
            return user;
        }

        [HttpGet]
        public async Task<AppUser> Profile()
        {          
            var user = await UserService.GetUserWithProperiesAsync(await GetCurrentId());
            return user;
        }
    }
}
