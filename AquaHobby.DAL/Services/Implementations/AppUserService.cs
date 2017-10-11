using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public bool RegisterUser(AppUser user)
        {
            UnitOfWork.UsersRepository.Add(user);
            UnitOfWork.Save();
            return true;
        }
    }
}
