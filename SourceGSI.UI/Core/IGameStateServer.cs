using System;
using SourceGSI.UI.Core.Entities;

namespace SourceGSI.UI.Core
{
    public interface IGameStateServer
    {
        int Port { get; set; }
        GameState GameState { get; }

        void Start();
        void Stop();
    }
}
