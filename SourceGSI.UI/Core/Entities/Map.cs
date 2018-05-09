using Newtonsoft.Json;
using SourceGSI.UI.Core.Entities.Lookup;

namespace SourceGSI.UI.Core.Entities
{
    public class Map
    {
        public string Name { get; set; }
        public long MatchId { get; set; }
        [JsonProperty("game_time")]
        public int GameTime { get; set; }
        [JsonProperty("clock_time")]
        public int ClockTime { get; set; }
        public bool IsDaytime { get; set; }
        [JsonProperty("nightstalker_night")]
        public bool IsNightstalkerNight { get; set; }
        [JsonProperty("game_state")]
        public Lookup.GameState GameState { get; set; }
        [JsonProperty("win_team")]
        public PlayerTeam WinTeam { get; set; }
        public string CustomGameName { get; set; }
        [JsonProperty("ward_purchase_cooldown")]
        public int WardPurchaseCooldown { get; set; }
    }
}
