using Battle.Domain.Core.Attack;
using Battle.Domain.Interfaces.Attack;
using UnityEngine;

namespace Battle.View
{
    public class AttackActiveView : MonoBehaviour
    {
        private AttackParameter _attackParameter;
        [SerializeField] private Collider2D col;

        private bool _setUpped;

        public void SetUp(AttackParameter attackParameter)
        {
            _attackParameter = attackParameter;
            _setUpped = true;
        }

        public void Activate(bool isActive)
        {
            col.enabled = isActive;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            
            if (!_setUpped)
                return;
            
            var passive = other.GetComponent<IAttackPassiveView>();
            passive?.OnAttacked(_attackParameter);
        }

    }
}