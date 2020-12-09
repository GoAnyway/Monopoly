using System;

namespace Database.Entities.GameEntities
{
    public class Dice
    {
        private static readonly Random Random = new Random();
        private static readonly object Lock = new object();

        public Dice()
        {
            lock (Lock)
            {
                Value = Random.Next(1, 7);
            }
        }

        public int Value { get; }
    }
}
