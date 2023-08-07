using BBG.Monolit.Configurations;
using BBG.Monolit.Models.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BBG.Monolit.DataAccess.ApplicationContext.PgSql
{
    public class PgSqlDbContext : IdentityDbContext<User>
    {
        public PgSqlDbContext(DbContextOptions<PgSqlDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new FriendConfiguration());
        }
    }
}