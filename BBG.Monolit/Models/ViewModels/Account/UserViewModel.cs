using BBG.Monolit.Models.Entities.Users;

namespace BBG.Monolit.Models.ViewModels.Account
{
    public class UserViewModel
    {
        public User User { get; set; }

        public UserViewModel(User user)
        {
            User = user;
        }

    }
}
