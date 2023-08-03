using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;

namespace BBG.Monolit.Models.Entities
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
            Image = "https://via.placeholder.com/500";
            Status = "Ура! Я в соцсети!";
            About = "Информация обо мне.";
        }
    }
}
