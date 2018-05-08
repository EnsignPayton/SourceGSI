using System;
using SourceGSI.UI.Core.Entities;

namespace SourceGSI.UI.Core
{
    public interface IGameStateServer
    {
        event EventHandler<GameStateEventArgs> ReceivedGameState;

        string RawJson { get; }
        GameState GameState { get; }

        void Start();
        void Stop();
    }
}
