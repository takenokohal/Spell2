using Battle.Domain.Core.Attack;
using Battle.Domain.Interfaces.Attack;
using UnityEngine;

namespace Battle.Test
{
    public class AttackHitTest : MonoBehaviour, IAttackPassiveView
    {
        public void OnAttacked(AttackParameter attackParameter)
        {
            Debug.Log(attackParameter.OwnerKey);
        }
    }
}