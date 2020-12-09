using System.Collections.Generic;
using Database.Entities.GameEntities.GameBoardObjects;
using Database.Entities.GameEntities.GameBoardObjects.PropertyEntities;
using Database.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;

namespace Database.Entities.GameEntities
{
    [Owned]
    public class Player
    {
        public User User { get; set; }
        public int Balance { get; set; } = 15000000;
        public ICollection<Property> PropertiesInOwnership { get; set; } = new List<Property>();
        public bool IsAlive { get; set; } = true;
        public Cell CurrentCell { get; set; }
        public Player NextPlayer { get; set; }
    }
}