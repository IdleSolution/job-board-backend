#nullable enable

using System;

namespace JobBoard.Models.Frontend
{
    public class LoginCredentials
    {
        public LoginCredentials(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}