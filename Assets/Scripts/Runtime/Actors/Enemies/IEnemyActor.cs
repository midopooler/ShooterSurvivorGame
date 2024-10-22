using PulkitMidha.ShooterSurvivor.Runtime.Actors.Players;
using PulkitMidha.ShooterSurvivor.Runtime.Components.Triggers;
using PulkitMidha.ShooterSurvivor.Runtime.Systems;
using UnityEngine;

namespace PulkitMidha.ShooterSurvivor.Runtime.Actors.Enemies
{
    internal interface IEnemyActor
    {
        public void DamageEnemy(int damage);
        public void DamageOverTime(int tickDamage, float tickInterval, float duration);
        public void PushEnemy(Vector2 force);
        public Transform EnemyTransform { get; }
    }
}
