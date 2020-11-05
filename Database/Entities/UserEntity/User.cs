using System;
using System.ComponentModel.DataAnnotations;
using Database.Entities.UserEntity.UserEnums;

namespace Database.Entities.UserEntity
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
            Role = UserRole.User;
            RegistrationTime = DateTime.UtcNow;
        }

        [Key] public Guid Id { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public UserRole Role { get; set; }
        public int Balance { get; set; }
        public string Nickname { get; set; }
        public DateTime RegistrationTime { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}