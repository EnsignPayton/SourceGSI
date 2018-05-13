using SourceGSI.UI.Core.Entities;

namespace SourceGSI.UI.Core.Events
{
    public class GameStateReceived
    {
        public GameState GameState { get; }

        public GameStateReceived(GameState gameState)
        {
            GameState = gameState;
        }
    }
}
