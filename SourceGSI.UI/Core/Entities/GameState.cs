using System.Collections.Generic;

namespace SourceGSI.UI.Core.Entities
{
    public class GameState
    {
        public Auth Auth { get; set; }
        public Provider Provider { get; set; }
        public Map Map { get; set; }
        public Player Player { get; set; }
        public Hero Hero { get; set; }
        public IList<Ability> Abilities { get; set; }
        public IList<Item> Items { get; set; }
        // TODO: Previously?
    }
}
