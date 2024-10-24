﻿using UnityEngine;

namespace PulkitMidha.ShooterSurvivor.Runtime.Components.Triggers
{
    internal readonly struct ColliderEnteredArgs
    {
        public Collider2D Collider { get; }

        public ColliderEnteredArgs(Collider2D collider)
        {
            Collider = collider;
        }
    }
}
