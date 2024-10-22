using NaughtyAttributes;
using PulkitMidha.ShooterSurvivor.Runtime.Actors.Players;
using PulkitMidha.ShooterSurvivor.Runtime.Actors.Projectiles;
using PulkitMidha.ShooterSurvivor.Runtime.Components.UpgradeHeader;
using UnityEngine;

namespace PulkitMidha.ShooterSurvivor.Runtime.Data.Upgrades
{
    [CreateAssetMenu(fileName = "New Upgrade_PoisonBullet", menuName = "LevelUp/Upgrade_PoisonBullet")]
    internal sealed class UpgradePoisonBullet : ScriptableObject, IPlayerUpgrade
    {
        [Range(0f, 1f)]
        [SerializeField]
        private float upgradeChance = 1;

        [Range(1f, 2f)]
        [SerializeField]
        private float damageTimeModifier = 1;

        [Required]
        [SerializeField]
        private PoisonProjectileActor poisonProjectileActor;

        [Required]
        [SerializeField]
        private LevelUpText upgradeText;

        public float UpgradeChance => upgradeChance;

        public void Apply(IPlayerController actorPlayer)
        {
            if (poisonProjectileActor)
            {
                var positionAbove = new Vector2(actorPlayer.PlayerTransform.position.x, actorPlayer.PlayerTransform.position.y + 1);
                Instantiate(upgradeText, positionAbove, Quaternion.identity);
                if (actorPlayer.ProjectileActor is PoisonProjectileActor poisonProjectile)
                {
                    poisonProjectile.damageDuration *= damageTimeModifier;
                }
                else
                {
                    actorPlayer.ProjectileActor = poisonProjectileActor;
                }
            }
        }

    }
}
