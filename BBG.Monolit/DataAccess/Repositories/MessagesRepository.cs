using BBG.Monolit.DataAccess.ApplicationContext.PgSql;
using BBG.Monolit.Models.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BBG.Monolit.DataAccess.Repositories
{
    public class MessagesRepository : Repository<Message>
    {
        public MessagesRepository(PgSqlDbContext db) : base(db) { }

        public List<Message> GetMessages(User sender, User recipient)
        {
            Set.Include(u => u.Recipient);
            Set.Include(u => u.Sender);

            var from = Set.AsEnumerable().Where(u => u.SenderId == sender.Id && u.RecipientId == recipient.Id).ToList();
            var to = Set.AsEnumerable().Where(u => u.SenderId == recipient.Id && u.RecipientId == sender.Id).ToList();

            var itog = new List<Message>();
            itog.AddRange(from);
            itog.AddRange(to);
            itog.OrderBy(m => m.Id);
            return itog;
        }
    }
}
