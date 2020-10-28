using System.Collections.Generic;
using Database.Entities.GameBoardObjects.Property;

namespace Database.Entities
{
    public class GameBoard
    {
        public ICollection<Property> Properties { get; set; }
    }
}