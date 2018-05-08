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
        public int LastHits { get; set; }
        public int Denies { get; set; }
        public int KillStreak { get; set; }
        public PlayerTeam Team { get; set; }
        public int Gold { get; set; }
        public int GoldReliable { get; set; }
        public int GoldUnreliable { get; set; }
        public int GoldPerMinute { get; set; }
        public int ExperiencePerMinute { get; set; }
    }
}
