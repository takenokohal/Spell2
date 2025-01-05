using Battle.Domain.Interfaces.Player;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Battle.Detail.ConstData
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