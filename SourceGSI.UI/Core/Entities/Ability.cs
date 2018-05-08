namespace SourceGSI.UI.Core.Entities
{
    public class Ability
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public bool CanCast { get; set; }
        public bool IsPassive { get; set; }
        public bool IsActive { get; set; }
        public int Cooldown { get; set; }
        public bool IsUltimate { get; set; }
    }
}
