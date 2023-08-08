using BBG.Monolit.DataAccess.ApplicationContext.PgSql;
using BBG.Monolit.Models.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBG.Monolit.DataAccess.Repositories
{
    public class FriendsRepository : Repository<Friend>
    {
        public FriendsRepository(PgSqlDbContext db) : base(db) { }

        public async Task AddFriend(User target, User Friend)
        {
            var friends = Set.AsEnumerable().FirstOrDefault(x => x.UserId == target.Id && x.CurrentFriendId == Friend.Id);

            if (friends == null)
            {
                var item = new Friend()
                {
                    UserId = target.Id,
                    User = target,
                    CurrentFriend = Friend,
                    CurrentFriendId = Friend.Id,
                };

                await CreateAsync(item);
            }
        }

        public async Task<List<User>> GetFriendsByUser(User target)
        {
            var friends = await Set.Include(x => x.CurrentFriend).Where(x => x.UserId == target.Id).Select(x => x.CurrentFriend).ToListAsync();

            return friends;
        }

        public async Task DeleteFriend(User target, User Friend)
        {
            var friends = Set.AsEnumerable().FirstOrDefault(x => x.UserId == target.Id && x.CurrentFriendId == Friend.Id);

            if (friends != null)
            {
                await DeleteAsync(friends);
            }
        }
    }
}
