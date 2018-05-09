using Newtonsoft.Json;
using SourceGSI.UI.Core.Entities.Lookup;

namespace SourceGSI.UI.Core.Entities
{
    public class Player
    {
        public string SteamId { get; set; }
        public string Name { get; set; }
        public PlayerActivity Activity { get; set; }
        public int Kills { get; set; }
        public int Death { get; set; }
        public int Assists { get; set; }
        [JsonProperty("last_hits")]
        public int LastHits { get; set; }
        public int Denies { get; set; }
        [JsonProperty("kill_streak")]
        public int KillStreak { get; set; }
        [JsonProperty("team_name")]
        public PlayerTeam Team { get; set; }
        public int Gold { get; set; }
        [JsonProperty("gold_reliable")]
        public int GoldReliable { get; set; }
        [JsonProperty("gold_unreliable")]
        public int GoldUnreliable { get; set; }
        public int GoldPerMinute { get; set; }
        public int ExperiencePerMinute { get; set; }
    }
}
