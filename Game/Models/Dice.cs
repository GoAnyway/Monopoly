using System;
using System.Collections.Generic;

namespace Game.Models
{
    public class Dice
    {
        private readonly Random _random = new Random();

        public IEnumerable<int> GetTwoRandomValues()
        {
            var random = new Random(DateTime.Now.Millisecond);

            return new[] {random.Next(1, 7), random.Next(1, 7)};
        }
    }
}