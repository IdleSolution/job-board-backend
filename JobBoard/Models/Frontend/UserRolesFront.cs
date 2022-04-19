using System.Collections.Generic;
using JobBoard.Models.Backend;

namespace JobBoard.Models.Frontend
{
    public class UserRolesFront
    {
        public UserRolesFront(string email, string userName, ICollection<string> roles)
        {
            Email = email;
            UserName = userName;
            Roles = roles;
        }
        public string Email { get; set; }
        public string UserName { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}