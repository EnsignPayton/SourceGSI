using Newtonsoft.Json;

namespace SourceGSI.UI.Core.Entities
{
    public class Item
    {
        public string Name { get; set; }
        public int Purchaser { get; set; }
        [JsonProperty("can_cast")]
        public bool CanCast { get; set; }
        public int Cooldown { get; set; }
        [JsonProperty("passive")]
        public bool IsPassive { get; set; }
        public int Charges { get; set; }
    }
}
