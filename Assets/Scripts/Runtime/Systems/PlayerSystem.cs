using NaughtyAttributes;
using PulkitMidha.ShooterSurvivor.Runtime.Actors.Players;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace PulkitMidha.ShooterSurvivor.Runtime.Systems
{
    internal sealed class PlayerSystem : MonoBehaviour, IPlayerSystem, IStartable
    {
        [Required]
        [SerializeField]
        private PlayerController actorPlayerPrefab;

        [Inject]
        private IObjectResolver objectResolver;
        private PlayerController actorPlayerInstance;

        public void Start()
        {
            if (!TryGetPlayer(out _))
            {
                actorPlayerInstance = objectResolver.Instantiate(
                    actorPlayerPrefab,
                    Vector3.zero,
                    Quaternion.identity
                );
            }
        }

        public bool TryGetPlayer(out IPlayerController actorPlayer)
        {
            if (actorPlayerInstance == false)
            {
                actorPlayer = default;
                return false;
            }

            actorPlayer = actorPlayerInstance;
            return true;
        }
    }
}
