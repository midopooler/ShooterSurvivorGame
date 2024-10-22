using PulkitMidha.ShooterSurvivor.Runtime.Actors.Enemies;
using PulkitMidha.ShooterSurvivor.Runtime.Components.Triggers;

namespace PulkitMidha.ShooterSurvivor.Runtime.Actors.Projectiles
{
    internal sealed class RifleProjectileActor : BaseProjectileActor
    {
        public override void DamageEnemy(ColliderEnteredArgs args)
        {
            var enemyActor = args.Collider.GetComponentInParent<IEnemyActor>();
            if (enemyActor == null)
            {
                return;
            }
            var pushDirection = (enemyActor.EnemyTransform.position - transform.position).normalized;
            enemyActor.DamageEnemy(projectileDamage);
            enemyActor.PushEnemy(pushDirection * pushForce);
            Destroy(gameObject);
        }
    }
}
