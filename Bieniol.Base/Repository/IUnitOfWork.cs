using System;
using System.Data.Entity;

namespace Bieniol.Base.Repository
{
    public interface IUnitOfWork<TDb>:IDisposable where TDb: DbContext 
    {
        void Save();
        TDb context { get; }
    }
}
