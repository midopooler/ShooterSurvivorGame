using PulkitMidha.ShooterSurvivor.Runtime.Actors.Players;

namespace PulkitMidha.ShooterSurvivor.Runtime.Components.Collectables
{
    internal interface ICollectable
    {
        public void Collect(IPlayerController player);
        public void FallowPlayer(IPlayerController player);
        public void DestroyCollectable();
    }
}
