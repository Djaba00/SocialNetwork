using BBG.Monolit.Models.Entities.Users;

namespace BBG.Monolit.Models.ViewModels.Account
{
    public class UserWithFriendExt : User
    {
        public bool IsFriendWithCurrent { get; set; }
    }
}
