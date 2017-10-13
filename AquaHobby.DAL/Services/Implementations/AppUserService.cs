using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaHobby.Models;
using AquaHobby.Models.Photos;
using AquaHobby.Models.User;

namespace AquaHobby.DAL.Services.Implementations
{
    public class AppUserService : IAppUserService
    {
        private AppUnityOfWork UnitOfWork;
        public AppUserService(AppUnityOfWork uof)
        {
            UnitOfWork = uof;
        }

        public void AddAquarium(Aquarium aquarium, string userId)
        {
            if (aquarium!=null && aquarium.Id != 0)
            {
                var user = UnitOfWork.UsersRepository.GetEntity(userId);
                aquarium.User = user;
                //user.Aquariums.Add(aquarium);          
                //update aquarium??
                UnitOfWork.Save();
            }
        }

        public void AddGallery(Gallery gallery, string userId)
        {
            gallery.UserId = userId;
            UnitOfWork.Save();
        }

        public void AddGallery(long galleryId, string userId)
        {
            var gallery = UnitOfWork.GalleriesRepository.GetEntity(galleryId);
            AddGallery(gallery, userId);
        }

        public void AddNewAquarium(Aquarium aquarium, string userId)
        {
            aquarium = UnitOfWork.AquariumsRepository.Add(aquarium);
            if (aquarium != null)
            {
                aquarium.OwnerId = userId;
                AddAquarium(aquarium, userId);
            }
        }

        public bool RegisterUser(AppUser user)
        {
            UnitOfWork.UsersRepository.Add(user);
            UnitOfWork.Save();
            return true;
        }
    }
}
