using AquaHobby.DAL;
using AquaHobby.DAL.Services;
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
    public class TestsController : ApiController
    {
        private ApplicationUserManager _userManager;
        private IAppUserService UserService;
        private AppUnityOfWork AppUnityOfWork;
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
        public TestsController(IAppUserService userService, AppUnityOfWork appUnityOfWork)
        {
            UserService = userService;
            AppUnityOfWork = appUnityOfWork;
        }
        [HttpGet]
        [Route("FullUser")]
        public async Task<AppUser> FullUser()
        {
            var identity = await UserManager.FindByNameAsync(User.Identity.Name);
            AppUser user;
            try
            {
                user = await UserService.GetUserWithProperiesAsync(identity.Id);

            }
            catch (Exception e)
            {

                throw;
            }

            return user;
        }

        [HttpGet]
        [Route("GetUser")]
        public  async Task<AppUser> GetUser()
        {
            var identity =await UserManager.FindByNameAsync(User.Identity.Name);
            AppUser user;
            try
            {
                user = UserService.GetUser(identity.Id);

            }
            catch (Exception e)
            {

                throw;
            }

            return user;
        }

        [HttpGet]
        [Route("GetGalleries")]
        public async Task<Gallery[]> GetGalleries()
        {
            var identity = await UserManager.FindByNameAsync(User.Identity.Name);
            Gallery[] gallery;
            try
            {
                gallery =await UserService.GetUserGalleriesAsync(identity.Id);

            }
            catch (Exception e)
            {

                throw;
            }

            return gallery;
        }

        [HttpGet]
        [Route("AddNewGallery")]
        public async Task AddNewGallery()
        {
            var identity = await UserManager.FindByNameAsync(User.Identity.Name);
            Gallery gallery = new Gallery();
            gallery.Name = "Galery for " + identity.UserName;
            gallery.OwnerId = identity.Id;
            try
            {
                gallery = AppUnityOfWork.GalleriesRepository.Add(gallery);
                UserService.AddGallery(gallery, identity.Id);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
