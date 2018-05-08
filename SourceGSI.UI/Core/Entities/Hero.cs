namespace SourceGSI.UI.Core.Entities
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool IsAlive { get; set; }
        public int SecondsToRespawn { get; set; }
        public int BuybackCost { get; set; }
        public int BuybackCooldown { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int HealthPercent { get; set; }
        public int Mana { get; set; }
        public int MaxMana { get; set; }
        public int ManaPercent { get; set; }
        public bool IsSilenced { get; set; }
        public bool IsStunned { get; set; }
        public bool IsDisarmed { get; set; }
        public bool IsMagicImmune { get; set; }
        public bool IsHexed { get; set; }
        public bool IsMuted { get; set; }
        public bool IsBreak { get; set; }
        public bool HasDebuff { get; set; }
    }
}
