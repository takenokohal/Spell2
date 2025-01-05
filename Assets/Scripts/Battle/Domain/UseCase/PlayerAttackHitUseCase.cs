/*using Battle.Domain.Core.Attack;
using Battle.Domain.Core.Player;
using Battle.Domain.Interfaces.Player;

namespace Battle.Domain.UseCase
{
    public class PlayerAttackHitUseCase
    {
        private readonly IPlayerAttackHitView _playerAttackHitView;
        private readonly IPlayerParameters _playerParameters;
        private readonly PlayerKey _playerKey;

        public PlayerAttackHitUseCase(IPlayerAttackHitView playerAttackHitView, PlayerKey playerKey)
        {
            _playerAttackHitView = playerAttackHitView;
            _playerKey = playerKey;
        }

        public void OnAttacked(AttackParameter attackParameter)
        {
            if (attackParameter.OwnerKey == _playerKey)
                return;
            
            if(!HitCheck())
                return;

            _playerAttackHitView.OnHit(attackParameter);
        }

        //無敵チェックとか
        private bool HitCheck()
        {
            return true;
        }
    }
}*/