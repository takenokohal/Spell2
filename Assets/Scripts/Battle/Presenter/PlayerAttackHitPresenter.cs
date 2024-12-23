using Battle.Model.Attack;
using Battle.Model.Player;
using UnityEngine;

namespace Battle.Presenter
{
    public class PlayerAttackHitPresenter : MonoBehaviour, IAttackPassiveView
    {
        private PlayerAttackHitController _playerAttackHitController;

        private bool _isConstructed;

        public void Construct(PlayerAttackHitController playerAttackHitController)
        {
            _playerAttackHitController = playerAttackHitController;
            _isConstructed = true;
        }

        void IAttackPassiveView.OnAttacked(AttackParameter attackParameter)
        {
            if (!_isConstructed)
                return;
            _playerAttackHitController.OnAttacked(attackParameter);
        }
    }
}