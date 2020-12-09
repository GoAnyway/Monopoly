using System.Linq;
using Models.GameModels;

namespace Game.Logic
{
    public class MonopolyGameLogic
    {
        public MonopolyGameModel StartGame(MonopolyGameModel game)
        {
            game.ActivePlayer = game.Players.First();

            return game;
        }

        public MonopolyGameModel StartNewTurn(MonopolyGameModel game)
        {
            FlipDices(game);
            ChangePlayerCurrentCell(game);

            return game;
        }

        private void FlipDices(MonopolyGameModel game) =>
            game.Dices = new[] { new DiceModel(), new DiceModel() };

        private void ChangePlayerCurrentCell(MonopolyGameModel game)
        {
            var dicesValue = game.Dices.Sum(_ => _.Value);
            var currentDiceIndex = game.ActivePlayer.CurrentCell.Index;
            var neededDiceIndex = (currentDiceIndex + dicesValue) % game.GameBoard.Cells.Count;

            game.ActivePlayer.CurrentCell.Players.Remove(game.ActivePlayer);
            game.ActivePlayer.CurrentCell = game.GameBoard.Cells.First(_ => _.Index == neededDiceIndex);
            game.ActivePlayer.CurrentCell.Players.Add(game.ActivePlayer);
        }

        private void GiveTurnToNextPlayer(MonopolyGameModel game) => 
            game.ActivePlayer = game.ActivePlayer.NextPlayer;

        public MonopolyGameModel BuyCell(MonopolyGameModel game)
        {
            if (cell.Player.Equals(game.ActivePlayer))
            {
                // Buy
            }

            return game;
        }
    }
}