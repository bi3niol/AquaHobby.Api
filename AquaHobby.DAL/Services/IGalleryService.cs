using AquaHobby.Models.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaHobby.DAL.Services
{
    public interface IGalleryService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>All galleries</returns>
        Task<Gallery[]> GetGalleriesAsync();

        Task<Photo[]> GetGalleryPhotosAsync(long galleryId);

        Gallery AddGallery(Gallery gallery);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="galleryId"></param>
        /// <param name="userId">loged user Id</param>
        /// <param name="photo">reference to database object very Important!!</param>
        /// <returns>true if photo was added to the gallery</returns>
        bool AddPhoto(long galleryId,string userId,Photo photo);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="galleryId"></param>
        /// <param name="userId">loged userId</param>
        /// <param name="photoId"></param>
        /// <returns>true if photo was added to the gallery</returns>
        bool AddPhoto(long galleryId,string userId,long photoId);

        Task<Gallery> GetGalleryAsync(long galleryId);

        bool Update(Gallery gallery,string userId);
    }
}
