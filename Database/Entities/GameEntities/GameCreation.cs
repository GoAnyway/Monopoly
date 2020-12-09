using System;
using System.Collections.Generic;
using Database.Entities.UserEntity;

namespace Database.Entities.GameEntities
{
    public class GameCreation
    {
        public GameCreation(User owner, string name, bool isPrivate = false)
        {
            Owner = owner;
            Name = name;
            IsPrivate = isPrivate;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public User Owner { get; set; }
        public ICollection<User> Players { get; set; }
        public int NumberOfPlayers => Players.Count;
        public bool IsPrivate { get; set; }
        public string Password { get; set; }
    }
}