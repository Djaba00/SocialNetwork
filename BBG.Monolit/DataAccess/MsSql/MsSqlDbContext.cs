using BBG.Monolit.Models.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BBG.Monolit.DataAccess.MsSql
{
    public class MsSqlDbContext : IdentityDbContext<User>
    {
        public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
