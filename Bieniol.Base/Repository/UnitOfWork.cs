using System;
using System.Data.Entity;

namespace Bieniol.Base.Repository
{
    public class UnitOfWork<TDb> : IUnitOfWork<TDb> where TDb: DbContext
    {
        public TDb context { get; }
        public UnitOfWork(TDb context)
        {
            this.context = context;
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
