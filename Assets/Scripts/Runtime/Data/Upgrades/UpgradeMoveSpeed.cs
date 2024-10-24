﻿using NaughtyAttributes;
using PulkitMidha.ShooterSurvivor.Runtime.Actors.Players;
using PulkitMidha.ShooterSurvivor.Runtime.Components.UpgradeHeader;
using UnityEngine;

namespace PulkitMidha.ShooterSurvivor.Runtime.Data.Upgrades
{
    [CreateAssetMenu(fileName = "New Upgrade_MoveSpeed", menuName = "LevelUp/Upgrade_MoveSpeed")]
    internal sealed class UpgradeMoveSpeed : ScriptableObject, IPlayerUpgrade
    {
        [Range(0f, 1f)]
        [SerializeField]
        private float upgradeChance = 1;

        [Range(1f, 2f)]
        [SerializeField]
        private float speedModifier = 1;

        [Required]
        [SerializeField]
        private LevelUpText upgradeText;

        public float UpgradeChance => upgradeChance;

        public void Apply(IPlayerController actorPlayer)
        {
            var positionAbove = new Vector2(actorPlayer.PlayerTransform.position.x, actorPlayer.PlayerTransform.position.y + 1);
            Instantiate(upgradeText, positionAbove, Quaternion.identity);
            actorPlayer.PlayerSpeed *= speedModifier;
        }

    }
}
