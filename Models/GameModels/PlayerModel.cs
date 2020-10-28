using System.Collections.Generic;
using Models.AuthenticationModels;
using Models.GameModels.CellModels;

namespace Models.GameModels
{
    public class PlayerModel
    {
        public UserModel User { get; set; }
        public int Balance { get; set; }
        public List<PropertyModel> PropertiesInOwnership { get; set; }
        public bool IsAlive { get; set; }
    }
}