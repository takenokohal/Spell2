using Battle.Model.Attack;
using Fusion;
using R3;
using R3.Triggers;
using UnityEngine;

namespace Battle.View
{
    public class AttackView : MonoBehaviour, IAttackView
    {
        private AttackParameter _attackParameter;
        [SerializeField] private Collider2D col;

        private bool _setUpped;

        void IAttackView.SetUp(AttackParameter attackParameter)
        {
            _attackParameter = attackParameter;

            this.OnTriggerEnter2DAsObservable().Subscribe(OnTrigger).AddTo(this);

            _setUpped = true;
        }

        void IAttackView.Activate(bool isActive)
        {
            col.enabled = isActive;
        }

        private void OnTrigger(Collider2D other)
        {
            if (!_setUpped)
                return;
            
            var passive = other.GetComponent<IAttackPassiveView>();
            passive?.OnAttacked(_attackParameter);
        }
    }
}