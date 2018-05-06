using System;

namespace SourceGSI.UI.Core
{
    public interface IGameStateServer
    {
        event EventHandler<GameStateEventArgs> ReceivedGameState;

        string CurrentGameState { get; }

        void Start();
        void Stop();
    }
}
