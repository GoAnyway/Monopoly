using System;
using System.Collections.Generic;

namespace Models.GameModels
{
    public class MonopolyGameModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public GameBoardModel GameBoard { get; set; }
        public List<PlayerModel> Players { get; set; }
        public int Turn { get; set; }
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        public DateTime FinishTime { get; set; }
        public DateTime LastUpdateTime { get; set; } = DateTime.UtcNow;
    }
}