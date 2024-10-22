namespace PulkitMidha.ShooterSurvivor.Runtime.Systems
{
    internal interface ILevelSystem
    {
        public int CurrentPlayerLevel { get; }
        public void PlayerLevelUp();
    }
}
