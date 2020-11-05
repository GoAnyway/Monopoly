using System.Collections.Generic;
using Models.AuthenticationModels;

namespace Models.HomeModels
{
    public class HomeModel
    {
        public HomeModel(UserModel user, ICollection<GameCreationModel> createdGames)
        {
            User = user;
            Games = createdGames;
        }

        public UserModel User { get; set; }
        public ICollection<GameCreationModel> Games { get; set; }
    }
}