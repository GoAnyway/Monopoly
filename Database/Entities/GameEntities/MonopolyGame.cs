using System;
using System.Collections.Generic;

namespace Database.Entities.GameEntities
{
    public class MonopolyGame
    {
        public MonopolyGame()
        {
            Id = Guid.NewGuid();
            StartTime = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public GameBoard GameBoard { get; set; }
        public ICollection<Player> Players { get; set; }
        public int Turn { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
    }
}