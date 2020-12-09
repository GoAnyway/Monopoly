using System.Collections.Generic;
using System.Drawing;
using Models.AuthenticationModels;
using Models.GameModels.CellModels;

namespace Models.GameModels
{
    public class PlayerModel
    {
        public UserModel User { get; set; }
        public int Balance { get; set; }
        public ICollection<PropertyModel> PropertiesInOwnership { get; set; }
        public bool IsAlive { get; set; }
        public CellModel CurrentCell { get; set; }
        public PlayerModel NextPlayer { get; set; }
    }
}