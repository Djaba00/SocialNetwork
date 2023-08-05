using System;
using BBG.Monolit.Models.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;

namespace BBG.Monolit.Models.Entities.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string About { get; set; }
        public string GetFullName()
        {
            return LastName + " " + " " + FirstName + " " + MiddleName;
        }

        public User()
        {
            Image = "https://thispersondoesnotexist.com/";
            Status = "Ура! Я в соцсети!";
            About = "Информация обо мне.";
        }
    }
}