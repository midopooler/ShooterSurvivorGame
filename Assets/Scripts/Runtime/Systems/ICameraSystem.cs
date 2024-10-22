using PulkitMidha.ShooterSurvivor.Runtime.Actors.Players;
using UnityEngine;

namespace PulkitMidha.ShooterSurvivor.Runtime.Systems
{
    internal interface ICameraSystem
    {
        public void FollowPlayer(IPlayerController actorPlayer);
        public bool TryGetCamera(out Camera targetCamera);
        public Vector2 GetOutsideCameraPosition(int offset);

    }
}
