using System;
using System.Collections.Generic;
using Database.Entities;
using Game.Models;

namespace Models.GameModels
{
    public class MonopolyGameModel
    {
        public MonopolyGameModel()
        {
            Id = Guid.NewGuid();
            GameBoard = new GameBoard();
            Dice = new Dice();
            StartTime = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public GameBoard GameBoard { get; set; }
        public Dice Dice { get; set; }
        public List<PlayerModel> Players { get; set; }
        public int Turn { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
    }
}