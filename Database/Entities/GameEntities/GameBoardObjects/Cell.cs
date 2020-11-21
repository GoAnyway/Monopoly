using System.ComponentModel.DataAnnotations;

namespace Database.Entities.GameEntities.GameBoardObjects
{
    public abstract class Cell
    {
        [Key]
        public int Index { get; set; }
    }
}