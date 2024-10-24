﻿using System.Collections.Generic;
using System.Linq;
using PulkitMidha.ShooterSurvivor.Runtime.Actors.Enemies;
using PulkitMidha.ShooterSurvivor.Runtime.Data.EnemySystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace PulkitMidha.ShooterSurvivor.Runtime.Systems
{
    internal sealed class EnemySystem : IEnemySystem, IStartable, ITickable
    {

        [Inject]
        private IObjectResolver objectResolver;

        private readonly EnemySystemSettings enemySystemSettings;
        private readonly ICameraSystem cameraSystem;

        private int spawnAreaOffset;
        private float enemySpawnRate;
        private float spawnTimer;

        private int maxEnemyCount;
        private readonly List<IEnemyActor> aliveEnemies = new List<IEnemyActor>();

        public int MaxEnemyCount
        {
            get => maxEnemyCount;
            set => maxEnemyCount = value;
        }

        public float EnemySpawnRate
        {
            get => enemySpawnRate;
            set => enemySpawnRate = value;
        }

        public List<IEnemyActor> AliveEnemies => aliveEnemies;

        public void Start()
        {
            spawnAreaOffset = enemySystemSettings.SpawnAreaOffset;
            enemySpawnRate = enemySystemSettings.EnemySpawnRate;
            maxEnemyCount = enemySystemSettings.InitialEnemyCount;
            spawnTimer = enemySpawnRate;
        }

        public void Tick()
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                var enemyPrefab = GetEnemyPrefab();
                SpawnEnemy(enemyPrefab);
                spawnTimer = enemySpawnRate;
            }
        }

        public EnemySystem(EnemySystemSettings enemySystemSettings, ICameraSystem cameraSystem)
        {
            this.enemySystemSettings = enemySystemSettings;
            this.cameraSystem = cameraSystem;
        }

        public void SpawnEnemy(EnemyActor enemyPrefab)
        {
            if (enemyPrefab == null || aliveEnemies.Count >= maxEnemyCount)
            {
                return;
            }
            var spawnPosition = cameraSystem.GetOutsideCameraPosition(spawnAreaOffset);
            var enemyActor = objectResolver.Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            TrackEnemy(enemyActor);
        }

        public void TrackEnemy(IEnemyActor enemyActor)
        {
            aliveEnemies.Add(enemyActor);
        }

        public void UntrackEnemy(IEnemyActor enemyActor)
        {
            aliveEnemies.Remove(enemyActor);
        }

        public EnemyActor GetEnemyPrefab()
        {
            var enemyPrefabs = enemySystemSettings.EnemyPrefabs;
            if (enemyPrefabs.Count == 1)
            {
                return enemyPrefabs.FirstOrDefault();
            }
            var totalWeight = enemyPrefabs.Sum(e => 1.0f / e.GetRarityLevel());
            var randomWeight = Random.Range(0, totalWeight);
            var cumulativeWeight = 0.0f;
            foreach (var enemyPrefab in enemyPrefabs)
            {
                cumulativeWeight += 1.0f / enemyPrefab.GetRarityLevel();
                if (randomWeight < cumulativeWeight)
                {
                    return enemyPrefab;
                }
            }
            return enemyPrefabs.FirstOrDefault();
        }
    }
}
