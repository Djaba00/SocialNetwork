using BBG.Monolit.DataAccess.ApplicationContext.PgSql;
using BBG.Monolit.Models.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBG.Monolit.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _db;

        public DbSet<T> Set { get; private set; }

        public Repository(PgSqlDbContext db)
        {
            _db = db;
            var set = _db.Set<T>();
            set.Load();

            Set = set;
        }

        public async Task CreateAsync(T item)
        {
            Set.Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(T item)
        {
            Set.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(T item)
        {
            Set.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await Set.FindAsync(id);
        }

        public async IAsyncEnumerable<T> GetAllAsync()
        {
            yield return (T)Set.GetAsyncEnumerator();
        }
    }
}
