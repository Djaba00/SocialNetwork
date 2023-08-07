using BBG.Monolit.Models.Entities.Users;
using System.Collections.Generic;

namespace BBG.Monolit.Models.ViewModels.Account
{
    public class UserViewModel
    {
        public User User { get; set; }

        public UserViewModel(User user)
        {
            User = user;
        }

        public List<User> Friends { get; set; }
    }
}
