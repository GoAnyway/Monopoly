using System.Collections.Generic;
using Database.Entities.GameEntities.GameBoardObjects;
using Microsoft.EntityFrameworkCore;

namespace Database.Entities.GameEntities
{
    [Owned]
    public class GameBoard
    {
        public ICollection<Cell> Cells { get; set; }
    }
}