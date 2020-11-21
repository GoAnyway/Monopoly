using Microsoft.EntityFrameworkCore;

namespace Database.Entities.GameEntities.GameBoardObjects.Default
{
    [Owned]
    public class Payment : Cell
    {
        public Payment(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
    }
}