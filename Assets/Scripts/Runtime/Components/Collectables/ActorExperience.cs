﻿using NaughtyAttributes;
using PulkitMidha.ShooterSurvivor.Runtime.Actors.Players;
using PulkitMidha.ShooterSurvivor.Runtime.Systems;
using UnityEngine;
using VContainer;

namespace PulkitMidha.ShooterSurvivor.Runtime.Components.Collectables
{
    internal sealed class ActorExperience: MonoBehaviour, ICollectable
    {
        [Min(1)]
        [SerializeField]
        private float collectableLifeTime = 20;

        [Min(1)]
        [SerializeField]
        private int experienceCount = 1;

        [Required]
        [SerializeField]
        private Rigidbody2D rigidBody;

        [Inject]
        private ICollectibleSystem system;

        [Inject]
        private ILevelSystem levelUpSystem;

        private IPlayerController actorPlayer;
        private float timer;

        private void Awake()
        {
            timer = collectableLifeTime;
        }

        private void FixedUpdate()
        {
            if (actorPlayer == null)
            {
                Decelerate();
            }
            else
            {
                var direction = (actorPlayer.PlayerTransform.position - transform.position).normalized;
                Move(direction, actorPlayer.PlayerSpeed);
            }

            CollectableSelfDestruct();
        }

        public void Collect(IPlayerController player)
        {
            if (player != null)
            {
                player.CurrentPlayerExperience += experienceCount;
                if (player.CurrentPlayerExperience > player.MaxPlayerExperience)
                {
                    levelUpSystem.PlayerLevelUp();
                    player.CurrentPlayerExperience = 0;
                }
                player.OnStatsChanged?.Invoke();
            }
            DestroyCollectable();
        }

        public void FallowPlayer(IPlayerController player)
        {
            this.actorPlayer = player;
        }

        public void Move(Vector2 direction, float speed)
        {
            var targetVelocity = direction.normalized * speed;
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, targetVelocity, Time.fixedDeltaTime * 10f);
        }

        public void Decelerate()
        {
            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.zero, 15 * Time.deltaTime);
            if (rigidBody.velocity.magnitude < 0.1f)
            {
                rigidBody.velocity = Vector2.zero;
            }
        }

        public void DestroyCollectable()
        {
            if (system != null && system.ActiveCollectibles.Contains(this))
            {
                system.UntrackCollectables(this);
            }
            Destroy(gameObject);
        }

        private void CollectableSelfDestruct()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                DestroyCollectable();
            }
        }
    }
}
