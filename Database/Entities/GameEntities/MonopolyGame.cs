using System;
using System.Collections.Generic;

namespace Database.Entities.GameEntities
{
    public class MonopolyGame
    {
        public Guid Id { get; set; }
        public GameBoard GameBoard { get; set; }
        public IList<Player> Players { get; set; }
        public int Turn { get; set; }
        public Player ActivePlayer { get; set; }
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        public DateTime FinishTime { get; set; }
        public DateTime LastUpdateTime { get; set; } = DateTime.UtcNow;
    }
}