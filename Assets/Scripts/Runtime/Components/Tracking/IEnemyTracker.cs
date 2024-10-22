using System;
using UnityEngine;

namespace PulkitMidha.ShooterSurvivor.Runtime.Components.Tracking
{
    internal interface IEnemyTracker
    {
        public event Action OnNoEnemiesLeft;
        public Transform GetClosestEnemy();
    }
}
