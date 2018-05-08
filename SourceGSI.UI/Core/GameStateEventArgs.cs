using System;
using SourceGSI.UI.Core.Entities;

namespace SourceGSI.UI.Core
{
    public class GameStateEventArgs : EventArgs
    {
        public GameState GameState { get; set; }
        public string RawJson { get; set; }
    }
}
