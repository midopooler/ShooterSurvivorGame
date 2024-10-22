using System;
using PulkitMidha.ShooterSurvivor.Runtime.Actors.Projectiles;
using PulkitMidha.ShooterSurvivor.Runtime.Components.Triggers;
using UnityEngine;

namespace PulkitMidha.ShooterSurvivor.Runtime.Actors.Players
{
    internal interface IPlayerController
    {
        public void DamagePlayer(int damage);
        public void PushPlayer(Vector2 force);
        public bool IsPlayerDead { get; }
        public Transform PlayerTransform { get; }
        public BaseProjectileActor ProjectileActor { get; set; }
        public int CurrentPlayerAmmo { get; set; }
        public int MaxPlayerHealth { get; set; }
        public int CurrentPlayerHealth { get; set; }
        public int MaxPlayerExperience { get; set; }
        public int CurrentPlayerExperience { get; set; }
        public int CurrentScoreCount { get; set; }
        public Action OnStatsChanged { get; set; }
        public float PlayerSpeed { get; set; }
        public float PlayerFireRate { get; set; }
    }
}
