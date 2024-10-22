using PulkitMidha.ShooterSurvivor.Runtime.Components.Triggers;

namespace PulkitMidha.ShooterSurvivor.Runtime.Actors.Projectiles
{
    internal interface IProjectileActor
    {
        public void MoveProjectile();
        public void DamageEnemy(ColliderEnteredArgs args);
        public void ProjectileSelfDestruct();
    }
}
