using Newtonsoft.Json;

namespace SourceGSI.UI.Core.Entities
{
    public class Hero
    {
        [JsonProperty("xpos")]
        public int XPosition { get; set; }
        [JsonProperty("ypos")]
        public int YPosition { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool IsAlive { get; set; }
        [JsonProperty("respawn_seconds")]
        public int SecondsToRespawn { get; set; }
        [JsonProperty("buyback_cost")]
        public int BuybackCost { get; set; }
        [JsonProperty("buyback_cooldown")]
        public int BuybackCooldown { get; set; }
        public int Health { get; set; }
        [JsonProperty("max_health")]
        public int MaxHealth { get; set; }
        [JsonProperty("health_percent")]
        public int HealthPercent { get; set; }
        public int Mana { get; set; }
        [JsonProperty("max_mana")]
        public int MaxMana { get; set; }
        [JsonProperty("mana_percent")]
        public int ManaPercent { get; set; }
        [JsonProperty("silenced")]
        public bool IsSilenced { get; set; }
        [JsonProperty("stunned")]
        public bool IsStunned { get; set; }
        [JsonProperty("disarmed")]
        public bool IsDisarmed { get; set; }
        [JsonProperty("magicimmune")]
        public bool IsMagicImmune { get; set; }
        [JsonProperty("hexed")]
        public bool IsHexed { get; set; }
        [JsonProperty("muted")]
        public bool IsMuted { get; set; }
        [JsonProperty("break")]
        public bool IsBreak { get; set; }
        [JsonProperty("has_debuff")]
        public bool HasDebuff { get; set; }
    }
}
