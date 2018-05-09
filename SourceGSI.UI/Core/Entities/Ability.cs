using Newtonsoft.Json;

namespace SourceGSI.UI.Core.Entities
{
    public class Ability
    {
        public string Name { get; set; }
        public int Level { get; set; }
        [JsonProperty("can_cast")]
        public bool CanCast { get; set; }
        [JsonProperty("passive")]
        public bool IsPassive { get; set; }
        [JsonProperty("ability_active")]
        public bool IsActive { get; set; }
        public int Cooldown { get; set; }
        [JsonProperty("ultimate")]
        public bool IsUltimate { get; set; }
    }
}
