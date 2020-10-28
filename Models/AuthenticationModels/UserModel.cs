using System;
using Models.AuthenticationModels.UserModelEnums;

namespace Models.AuthenticationModels
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public int Balance { get; set; }
        public string Nickname { get; set; }
        public DateTime RegistrationTime { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}