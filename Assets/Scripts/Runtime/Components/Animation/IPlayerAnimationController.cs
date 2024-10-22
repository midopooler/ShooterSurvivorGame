using UnityEngine;

namespace PulkitMidha.ShooterSurvivor.Runtime.Components.Animation
{
    internal interface IPlayerAnimationController
    {
        public void UpdateAnimation(Vector2 playerDirection, Transform enemyTransform, Vector3 playerPosition);
        public void ShowPlayerDeath();
    }
}
