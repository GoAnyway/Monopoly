using System.Collections.Generic;
using Database.Entities.GameEntities.GameBoardObjects.Property;
using Database.Entities.UserEntity;

namespace Database.Entities.GameEntities
{
    public class Player
    {
        public User User { get; set; }
        public int Balance { get; set; }
        public ICollection<Property> PropertiesInOwnership { get; set; }
        public bool IsAlive { get; set; }
    }
}