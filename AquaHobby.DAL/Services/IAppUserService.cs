using AquaHobby.Models;
using AquaHobby.Models.Photos;
using AquaHobby.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaHobby.DAL.Services
{
    public interface IAppUserService
    {
        bool RegisterUser(AppUser user);
        /// <summary>
        /// Insert new aquarium to Database and ser teration with user indicated by given id
        /// </summary>
        /// <param name="aquarium">new aquarium</param>
        /// <param name="userId"></param>
        void AddNewAquarium(Aquarium aquarium, string userId);
        /// <summary>
        /// add existing aquarium to user
        /// </summary>
        /// <param name="aquarium">existing aquarium in DB</param>
        /// <param name="userId"></param>
        void AddAquarium(Aquarium aquarium, string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gallery">reference to DB object of Gallery</param>
        /// <param name="userId"></param>
        bool AddGallery(Gallery gallery, string userId);
        Task<bool> AddGallery(long galleryId, string userId);

        Task<AppUser> GetUserWithProperiesAsync(string userId);
        Task<AppUser[]> GetUsersAsync();
        Task<AppUser> GetUser(string userId);
        Task<Gallery[]> GetUserGalleriesAsync(string userId);
        Task<Aquarium[]> GetUserAquariumsAsync(string userId);
    }
}
