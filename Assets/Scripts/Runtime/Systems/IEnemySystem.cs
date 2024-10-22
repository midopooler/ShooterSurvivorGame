using System.Collections.Generic;
using PulkitMidha.ShooterSurvivor.Runtime.Actors.Enemies;

namespace PulkitMidha.ShooterSurvivor.Runtime.Systems
{
    internal interface IEnemySystem
    {
        public void SpawnEnemy(EnemyActor enemyPrefab);
        public EnemyActor GetEnemyPrefab();
        public void TrackEnemy(IEnemyActor enemyActor);
        public void UntrackEnemy(IEnemyActor enemyActor);
        public int MaxEnemyCount { get; set; }
        public float EnemySpawnRate { get; set; }
        public List<IEnemyActor> AliveEnemies { get; }
    }
}
