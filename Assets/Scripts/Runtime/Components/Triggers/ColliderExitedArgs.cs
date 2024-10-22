using UnityEngine;

namespace PulkitMidha.ShooterSurvivor.Runtime.Components.Triggers
{
    internal readonly struct ColliderExitedArgs
    {
        public Collider2D Collider { get; }

        public ColliderExitedArgs(Collider2D collider)
        {
            Collider = collider;
        }
    }
}
