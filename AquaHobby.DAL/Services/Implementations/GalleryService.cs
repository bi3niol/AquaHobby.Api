using System;
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

        public Gallery AddGallery(Gallery gallery,string userId)
        {
            if (gallery == null)
                return null;
            gallery.OwnerId = userId;
            var _gallery = UnitOfWork.GalleriesRepository.Add(gallery);
            UnitOfWork.Save();
            return _gallery;
        }

        public async Task<Photo> AddNewPhoto(long galleryId, string userId, Photo photo)
        {
            if (photo == null)
                return null;
            var gall = await UnitOfWork.GalleriesRepository.GetEntityAsync(galleryId);
            if (gall.OwnerId != userId)
                return null;
            photo.GalleryId = galleryId;
            photo.OwnerId = userId;
            var res = UnitOfWork.PhotosRepository.Add(photo);
            UnitOfWork.Save();
            return res;
        }

        public async Task<bool> AddPhoto(long galleryId, string userId, Photo photo)
        {
            if (photo == null)
                return false;
            if (userId != photo.OwnerId)
                return false;
            var gall = await UnitOfWork.GalleriesRepository.GetEntityAsync(galleryId);
            if (gall.OwnerId != userId)
                return false;
            photo.GalleryId = galleryId;
            UnitOfWork.Save();
            return true;
        }

        public async Task<bool> AddPhoto(long galleryId, string userId, long photoId)
        {
            var photo = await UnitOfWork.PhotosRepository.GetEntityAsync(photoId);
            return await AddPhoto(galleryId, userId, photo);
        }

        public async Task<Gallery[]> GetGalleriesAsync()
        {
            return await UnitOfWork.GalleriesRepository.GetAll().ToArrayAsync();
        }

        public async Task<Gallery> GetGalleryAsync(long galleryId)
        {
            var gallery = await UnitOfWork.GalleriesRepository.GetEntityAsync(galleryId);
            if (gallery != null)
                await UnitOfWork.context.Entry(gallery).Collection(g => g.Photos).LoadAsync();
            return gallery;
        }

        public async Task<Photo[]> GetGalleryPhotosAsync(long galleryId)
        {
            var res = await UnitOfWork.PhotosRepository.GetEntityByExpression(p => p.GalleryId == galleryId).ToArrayAsync();
            return res;
        }

        public bool Update(Gallery gallery, string userId)
        {
            if (gallery == null || gallery.OwnerId != userId)
                return false;
            UnitOfWork.GalleriesRepository.Update(gallery);
            UnitOfWork.Save();
            return true;
        }
    }
}
