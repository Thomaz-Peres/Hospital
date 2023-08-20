using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Doctors.Domain.Entities
{
    public class User : IdentityUser
    {
        public User(string userName)
        {
            UserName = userName;
        }
        public bool Active { get; set; } = true;
    }
}