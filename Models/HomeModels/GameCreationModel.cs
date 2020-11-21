using System;
using System.Collections.Generic;
using Models.AuthenticationModels;

namespace Models.HomeModels
{
    public class GameCreationModel
    {
        public GameCreationModel()
        {
            
        }

        public GameCreationModel(UserModel owner, string name, bool isPrivate = false)
        {
            Id = Guid.NewGuid();
            Owner = owner;
            Name = name;
            IsPrivate = isPrivate;
            Players = new List<UserModel>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public UserModel Owner { get; set; }
        public ICollection<UserModel> Players { get; set; }
        public int NumberOfPlayers => Players.Count;
        public bool IsPrivate { get; set; }
        public string Password { get; set; }
    }
}