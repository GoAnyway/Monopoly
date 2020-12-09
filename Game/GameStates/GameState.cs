using System.Linq;
using Models.GameModels;

namespace Game.GameStates
{
    //TODO GameState Implementation
    public abstract class GameState
    {
        public abstract void EnterState(MonopolyGameModel context);
        public abstract void GoToNextState(MonopolyGameModel context);
    }

    public class NewTurnState : GameState
    {
        public override void EnterState(MonopolyGameModel context)
        {
            FlipDices(context);
            ChangePlayerCurrentCell(context);

            context.CurrentGameState = this;
        }

        public override void GoToNextState(MonopolyGameModel context) => throw new System.NotImplementedException();

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
    }

    public class WaitingState : GameState
    {
        public override void EnterState(MonopolyGameModel context)
        {
           
        }

        public override void GoToNextState(MonopolyGameModel context) => 
            context.CurrentGameState = this;
    }

    public class StartState : GameState
    {
        public override void EnterState(MonopolyGameModel context)
        {
            context.ActivePlayer = context.Players.First();
            context.CurrentGameState = this;
        }

        public override void GoToNextState(MonopolyGameModel context) => 
            context.CurrentGameState = new NewTurnState();

    }
}