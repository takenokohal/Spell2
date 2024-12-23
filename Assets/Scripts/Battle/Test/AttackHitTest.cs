using Battle.Model.Attack;
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