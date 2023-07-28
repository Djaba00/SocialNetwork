using System;
using BBG.Monolit.DataAccess.Repositories;

namespace BBG.Monolit.DataAccess.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges(bool ensureAutoHistory = false);

        IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = true) 
            where TEntity : class;
    }
}
