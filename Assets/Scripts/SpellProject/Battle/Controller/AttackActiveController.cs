using SpellProject.Battle.Domain.Core.Attack;
using SpellProject.Battle.Domain.Interfaces.Attack;
using UnityEngine;

namespace SpellProject.Battle.Controller
{
    public class AttackActiveController : MonoBehaviour
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
            
            var passive = other.GetComponent<IAttackPassiveController>();
            passive?.OnAttacked(_attackParameter);
        }

    }
}