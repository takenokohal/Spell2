using Battle.Model.Player;
using UnityEngine;

namespace Battle.Model.Attack
{
    public class PlayerAttackHitController
    {
        private readonly IPlayerAttackHitView _playerAttackHitView;
        private readonly PlayerKey _playerKey;

        public PlayerAttackHitController(IPlayerAttackHitView playerAttackHitView, PlayerKey playerKey)
        {
            _playerAttackHitView = playerAttackHitView;
            _playerKey = playerKey;
        }

        public void OnAttacked(AttackParameter attackParameter)
        {
            if (attackParameter.OwnerKey == _playerKey)
                return;

            _playerAttackHitView.OnHit(attackParameter);
        }

        //無敵チェックとか
        private bool HitCheck()
        {
            return true;
        }
    }
}