using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaHobby.DAL
{
    public class AquaHobbyContext:DbContext
    {
        private static int i = 0;
        public AquaHobbyContext()
        {
            ++i;
        }
    }
}
