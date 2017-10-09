using AquaHobby.Repository;
using Bieniol.Base.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaHobby.DAL
{
    public class AppUnityOfWork : UnitOfWork<DbContext>
    {
        public IAppUsersRepository UsersRepository { get; }
        public IAquariumsRepository AquariumsRepository { get; }
        public IFishRepository FishRepository { get; set; }
        public IGalleriesRepository GalleriesRepository { get; set; }
        public IHealthBooksRepository HealthBooksRepository { get; set; }
        public IIllnessesRepository IllnessesRepository { get; set; }
        public IKindNotyficationsRepository KindNotyficationsRepository { get; set; }
        public IKindsRepository KindsRepository { get; set; }
        public INursingsRepository NursingsRepository { get; set; }
        public IObservationsRepository ObservationsRepository { get; set; }
        public IPhotosRepository PhotosRepository { get; set; }
        public IWaterChangesRepository WaterChangesRepository { get; set; }

        //public AppUnityOfWork(DbContext context) : base(context)
        //{ }
        public AppUnityOfWork(IAppUsersRepository UsersRepository, IAquariumsRepository AquariumsRepository, IFishRepository FishRepository,
           IGalleriesRepository GalleriesRepository, IHealthBooksRepository HealthBooksRepository, IIllnessesRepository IllnessesRepository,
           IKindNotyficationsRepository KindNotyficationsRepository, IKindsRepository KindsRepository, INursingsRepository NursingsRepository,
           IObservationsRepository ObservationsRepository, IPhotosRepository PhotosRepository, IWaterChangesRepository WaterChangesRepository,DbContext context):base(context)
        {

            int i = 0;
        }
    }
}
