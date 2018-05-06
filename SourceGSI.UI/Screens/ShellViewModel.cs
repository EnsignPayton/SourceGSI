using Caliburn.Micro;
using SourceGSI.UI.Core;

namespace SourceGSI.UI.Screens
{
    public class ShellViewModel : Conductor<IScreen>
    {
        private readonly IGameStateServer _gameStateServer;

        public string GameState => _gameStateServer.CurrentGameState ?? "Awaiting Game State";

        public ShellViewModel(IGameStateServer gameStateServer)
        {
            _gameStateServer = gameStateServer;
        }

        protected override void OnInitialize()
        {
            _gameStateServer.ReceivedGameState += ReceivedGameState;
            _gameStateServer.Start();

            base.OnInitialize();
        }

        private void ReceivedGameState(object sender, GameStateEventArgs e)
        {
            NotifyOfPropertyChange(() => GameState);
        }
    }
}
