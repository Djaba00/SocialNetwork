using BBG.Monolit.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BBG.Monolit.DataAccess.PgSql
{
    public class PgSqlDbContext : IdentityDbContext<User>
    {
        public PgSqlDbContext(DbContextOptions<PgSqlDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
