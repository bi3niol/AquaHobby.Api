﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaHobby.Models.Photos;
using System.Data.Entity;

namespace AquaHobby.DAL.Services.Implementations
{
    public class GalleryService : IGalleryService
    {
        private AppUnityOfWork UnitOfWork;
        public GalleryService(AppUnityOfWork uof)
        {
            UnitOfWork = uof;
        }

        public Gallery AddGallery(Gallery gallery)
        {
            return UnitOfWork.GalleriesRepository.Add(gallery);
        }

        public bool AddPhoto(long galleryId, string userId, Photo photo)
        {
            if (photo == null)
                return false;
            if (userId != photo.OwnerId)
                return false;
            photo.GalleryId = galleryId;
            UnitOfWork.Save();
            return true;
        }

        public bool AddPhoto(long galleryId, string userId, long photoId)
        {
            var photo = UnitOfWork.PhotosRepository.GetEntity(photoId);
            return AddPhoto(galleryId, userId, photo);
        }

        public async Task<Gallery[]> GetGalleriesAsync()
        {
            return await UnitOfWork.GalleriesRepository.GetAll().ToArrayAsync();
        }

        public async Task<Gallery> GetGalleryAsync(long galleryId)
        {
            var gallery = UnitOfWork.GalleriesRepository.GetEntity(galleryId);
            if (gallery != null)
               await UnitOfWork.context.Entry(gallery).Collection(g => g.Photos).LoadAsync();
            return gallery;
        }

        public async Task<Photo[]> GetGalleryPhotosAsync(long galleryId)
        {
           var res = await UnitOfWork.PhotosRepository.GetEntityByExpression(p => p.GalleryId == galleryId).ToArrayAsync();
            return res;
        }

        public void Update(Gallery gallery)
        {
            UnitOfWork.GalleriesRepository.Update(gallery);
            UnitOfWork.Save();
        }
    }
}