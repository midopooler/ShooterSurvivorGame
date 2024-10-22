using System.Collections.Generic;
using PulkitMidha.ShooterSurvivor.Runtime.Components.Collectables;
using PulkitMidha.ShooterSurvivor.Runtime.Data.LootTables;
using UnityEngine;

namespace PulkitMidha.ShooterSurvivor.Runtime.Systems
{
    internal interface ICollectibleSystem
    {
        public void SpawnCollectables(CollectibleTableData collectibleTable, Vector2 position, float spreadRadius);
        public void TrackCollectables(ICollectable collectable);
        public void UntrackCollectables(ICollectable collectable);
        public void DestroyAllCollectables();
        public List<ICollectable> ActiveCollectibles { get; }
    }
}
