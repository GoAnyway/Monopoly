using System;

namespace Models.GameModels
{
    public class DiceModel
    {
        private static readonly Random Random = new Random();
        private static readonly object Lock = new object();

        public DiceModel()
        {
            lock (Lock)
            {
                Value = Random.Next(1, 7);
            }
        }

        public int Value { get; }
    }
}