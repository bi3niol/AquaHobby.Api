﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaHobby.Models;
using AquaHobby.Models.Photos;
using AquaHobby.Models.User;
using System.Data.Entity;

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
                aquarium.UserId = userId;
                UnitOfWork.AquariumsRepository.Update(aquarium);
                UnitOfWork.Save();
            }
        }

        public bool AddGallery(Gallery gallery, string userId)
        {
            if (gallery.OwnerId != userId)
                return false;
            gallery.UserId = userId;
            UnitOfWork.Save();
            return true;
        }

        public bool  AddGallery(long galleryId, string userId)
        {
            var gallery = UnitOfWork.GalleriesRepository.GetEntity(galleryId);
            return AddGallery(gallery, userId);
        }

        public void AddNewAquarium(Aquarium aquarium, string userId)
        {
            aquarium = UnitOfWork.AquariumsRepository.Add(aquarium);
            if (aquarium != null)
            {
                aquarium.OwnerId = userId;

            }
        }

        public AppUser GetUser(string userId)
        {
            return UnitOfWork.UsersRepository.GetEntity(userId);
        }

        public async Task<Aquarium[]> GetUserAquariumsAsync(string userId)
        {
            var aquariums = await UnitOfWork.AquariumsRepository.GetEntityByExpression(a=>a.UserId==userId).ToArrayAsync();
            return aquariums;
        }

        public async Task<Gallery[]> GetUserGalleriesAsync(string userId)
        {
            var galleriesQuery = UnitOfWork.GalleriesRepository.GetEntityByExpression(g => g.UserId == userId);
            var galleries = await galleriesQuery.ToArrayAsync();
            return galleries;
        }

        public async Task<AppUser[]> GetUsersAsync()
        {
            return await UnitOfWork.UsersRepository.GetAll().ToArrayAsync();
        }

        public async Task<AppUser> GetUserWithProperiesAsync(string userId)
        {            
            var user = UnitOfWork.UsersRepository.GetEntity(userId);
            var entry = UnitOfWork.context.Entry(user);
            await entry.Collection(u => u.Aquariums).LoadAsync();
            await entry.Collection(u => u.Gallery).LoadAsync();
            return user;
        }

        public bool RegisterUser(AppUser user)
        {
            UnitOfWork.UsersRepository.Add(user);
            UnitOfWork.Save();
            return true;
        }
    }
}
