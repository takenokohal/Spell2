using System;
using UnityEngine;

namespace SpellProject.Battle.Domain.ValueObject
{
    [Serializable]
    public struct BattleConstData
    {
        [SerializeField] private int playerMaxLife;
        public int PlayerMaxLife => playerMaxLife;
        
        [SerializeField] private float playerMoveSpeed;
        public float PlayerMoveSpeed => playerMoveSpeed;

        [SerializeField] private float magicCircleShowDuration;
        public float MagicCircleShowDuration => magicCircleShowDuration;
    }
}