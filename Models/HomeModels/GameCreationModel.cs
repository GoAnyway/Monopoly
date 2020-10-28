using System.Collections.Generic;
using Models.AuthenticationModels;

namespace Models.HomeModels
{
    public class GameCreationModel
    {
        public List<UserModel> Players { get; set; }
        public int NumberOfPlayers { get; set; }
        public bool IsPrivate { get; set; }
    }
}