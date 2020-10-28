using System;
using System.Collections.Generic;

namespace Database.Entities
{
    public class GameState
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public GameBoard GameBoard { get; set; }
        public ICollection<Player> Players { get; set; }
        public int Turns { get; set; }
    }
}