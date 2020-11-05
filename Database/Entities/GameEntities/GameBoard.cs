using System.Collections.Generic;
using Database.Entities.GameEntities.GameBoardObjects.Property;

namespace Database.Entities.GameEntities
{
    public class GameBoard
    {
        public ICollection<Property> Properties { get; set; }
    }
}