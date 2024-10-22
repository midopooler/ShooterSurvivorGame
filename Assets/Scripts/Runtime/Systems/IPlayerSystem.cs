using PulkitMidha.ShooterSurvivor.Runtime.Actors;
using PulkitMidha.ShooterSurvivor.Runtime.Actors.Players;

namespace PulkitMidha.ShooterSurvivor.Runtime.Systems
{
    internal interface IPlayerSystem
    {
        public bool TryGetPlayer(out IPlayerController actorPlayer);
    }
}
