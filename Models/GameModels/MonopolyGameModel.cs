using System;
using System.Collections.Generic;

namespace Models.GameModels
{
    public class MonopolyGameModel
    {
        public Guid Id { get; set; }
        public GameBoardModel GameBoard { get; set; }
        public IList<PlayerModel> Players { get; set; }
        public int Turn { get; set; }
        public PlayerModel ActivePlayer { get; set; }
        public IEnumerable<DiceModel> Dices { get; set; }
        public object CurrentGameState { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}