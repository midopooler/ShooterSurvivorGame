﻿using UnityEngine;

namespace PulkitMidha.ShooterSurvivor.Runtime.Components.Rotation
{
    internal interface IPlayerRotation
    {
        public bool IsPlayerInverted { get; }
        public void InvertPlayer(Vector2 joystickInput, Transform enemyTransform);
    }
}
