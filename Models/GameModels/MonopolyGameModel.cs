using System;
using System.Collections.Generic;

namespace Models.GameModels
{
    public class MonopolyGameModel
    {
        public MonopolyGameModel()
        {
            Id = Guid.NewGuid();
            StartTime = DateTime.UtcNow;
            LastUpdateTime = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public GameBoardModel GameBoard { get; set; }
        public List<PlayerModel> Players { get; set; }
        public int Turn { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}