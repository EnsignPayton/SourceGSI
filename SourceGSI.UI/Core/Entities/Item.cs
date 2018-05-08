namespace SourceGSI.UI.Core.Entities
{
    public class Item
    {
        public string Name { get; set; }
        public string CantainsRune { get; set; } // TODO: To enum
        public bool CanCast { get; set; }
        public int Cooldown { get; set; }
        public bool IsPassive { get; set; }
        public int Charges { get; set; }
    }
}
