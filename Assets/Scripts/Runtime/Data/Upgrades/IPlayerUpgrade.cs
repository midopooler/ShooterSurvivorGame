using PulkitMidha.ShooterSurvivor.Runtime.Actors.Players;

namespace PulkitMidha.ShooterSurvivor.Runtime.Data.Upgrades
{
    internal interface IPlayerUpgrade
    {
        public void Apply(IPlayerController actorPlayer);
        public float UpgradeChance { get; }
    }
}
