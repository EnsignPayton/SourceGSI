using Caliburn.Micro;
using SourceGSI.UI.Core;
using SourceGSI.UI.Core.Entities;

namespace SourceGSI.UI.Screens
{
    public class ShellViewModel : Conductor<IScreen>
    {
        private readonly IGameStateServer _gameStateServer;

        public string RawJson => _gameStateServer.RawJson ?? "Awaiting Game State";
        public GameState GameState => _gameStateServer.GameState;

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
