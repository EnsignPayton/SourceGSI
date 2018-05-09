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

        public string Name => DotaApi.HeroNames.TryGetValue(GameState?.Hero?.Name ?? string.Empty, out string result) ? result : GameState?.Hero?.Name;
        public string Health => $"{GameState?.Hero?.Health ?? 0} / {GameState?.Hero?.MaxHealth ?? 0}";
        public string Mana => $"{GameState?.Hero?.Mana ?? 0} / {GameState?.Hero?.MaxMana ?? 0}";

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
            NotifyOfPropertyChange(() => RawJson);
            NotifyOfPropertyChange(() => GameState);
            NotifyOfPropertyChange(() => Name);
            NotifyOfPropertyChange(() => Health);
            NotifyOfPropertyChange(() => Mana);
        }
    }
}
