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
    }
}
