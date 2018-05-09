using System.Collections.Generic;

namespace SourceGSI.UI.Core
{
    public static class DotaApi
    {
        public static IDictionary<string, string> HeroNames = new Dictionary<string, string>()
        {
            { "npc_dota_hero_antimage", "Anti-Mage" },
            { "npc_dota_hero_axe", "Axe" }
        };
    }
}
