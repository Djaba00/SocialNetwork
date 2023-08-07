using BBG.Monolit.DataAccess.ApplicationContext.PgSql;
using BBG.Monolit.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace BBG.Monolit.DataAccess.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public PgSqlDbContext _context;
        private Dictionary<Type, object> _repositories;
        public UnitOfWork(PgSqlDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {

        }

        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = true) where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<Type, object>();
            }

            if (hasCustomRepository)
            {
                var customRepo = _context.GetService<IRepository<TEntity>>();
                if (customRepo != null)
                {
                    return customRepo;
                }
            }

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<TEntity>(_context);
            }

            return (IRepository<TEntity>)_repositories[type];
        }

        public int SaveChanges(bool enshureAutohistory = false)
        {
            throw new NotImplementedException();
        }
    }
}
