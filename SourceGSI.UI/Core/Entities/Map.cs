using SourceGSI.UI.Core.Entities.Lookup;

namespace SourceGSI.UI.Core.Entities
{
    public class Map
    {
        public string Name { get; set; }
        public long MatchId { get; set; }
        public int GameTime { get; set; }
        public int ClockTime { get; set; }
        public bool IsDaytime { get; set; }
        public bool IsNightstalkerNight { get; set; }
        public GameState GameState { get; set; }
        public PlayerTeam WinTeam { get; set; }
        public string CustomGameName { get; set; }
        public int WardPurchaseCooldown { get; set; }
    }
}
