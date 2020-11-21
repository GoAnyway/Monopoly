using System.Collections.Generic;
using Database.Entities.GameEntities.GameBoardObjects.PropertyEntities;
using Database.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;

namespace Database.Entities.GameEntities
{
    [Owned]
    public class Player
    {
        public User User { get; set; }
        public int Balance { get; set; }
        public ICollection<Property> PropertiesInOwnership { get; set; }
        public bool IsAlive { get; set; }
    }
}