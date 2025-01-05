using Sirenix.OdinInspector;
using SpellProject.Battle.Domain.Interfaces.Player;
using UnityEngine;

namespace SpellProject.Battle.Detail.ConstData
{
    [CreateAssetMenu(menuName = "Create PlayerConstData", fileName = "PlayerConstData", order = 0)]
    public class PlayerConstData : SerializedScriptableObject , IPlayerConstData
    {
        [SerializeField] private float moveSpeed;

        public float MoveSpeed => moveSpeed;

        [SerializeField] private int playerMaxLife;

        public int PlayerMaxLife => playerMaxLife;
    }
}