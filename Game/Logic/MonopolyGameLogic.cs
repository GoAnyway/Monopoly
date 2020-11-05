using Models.GameModels;

namespace Game.Logic
{
    public class MonopolyGameLogic
    {
        private MonopolyGameModel _game;

        public void StartGame(MonopolyGameModel game)
        {
            _game = game;
        }
    }
}