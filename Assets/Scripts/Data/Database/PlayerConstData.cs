using Sirenix.OdinInspector;
using UnityEngine;

namespace Data.Database
{
    [CreateAssetMenu(menuName = "Create PlayerConstData", fileName = "PlayerConstData", order = 0)]
    public class PlayerConstData : SerializedScriptableObject
    {
        [SerializeField] private float moveSpeed;

        public float MoveSpeed => moveSpeed;
    }
}