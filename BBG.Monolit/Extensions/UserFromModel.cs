using BBG.Monolit.Models.Entities.Users;
using BBG.Monolit.Models.ViewModels.Account;

namespace BBG.Monolit.Extensions
{
    public static class UserFromModel
    {
        public static User Convert(this User user, UserEditViewModel userEditVm)
        {
            user.FirstName = userEditVm.FirstName;
            user.LastName = userEditVm.LastName;
            user.MiddleName = userEditVm.MiddleName;
            user.BirthDate = userEditVm.BirthDate.ToUniversalTime();
            user.Email = userEditVm.Email;
            user.UserName = userEditVm.UserName;
            user.Image = userEditVm.Image;
            user.Status = userEditVm.Status;
            user.About = userEditVm.About;

            return user;
        }
    }
}
