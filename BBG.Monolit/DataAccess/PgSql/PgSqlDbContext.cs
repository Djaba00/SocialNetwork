using BBG.Monolit.Configurations;
using BBG.Monolit.Models.Entities.Users;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration<Friend>(new FriendConfiguration());
        }
    }
}
