using R3;
using SpellProject.Battle.Domain.Core.Attack;
using SpellProject.Battle.Domain.Core.Player;

namespace SpellProject.Battle.Domain.UseCase
{
    public class PlayerAttackPassiveUseCase
    {
        private readonly PlayerParameters _playerParameters;
        private readonly PlayerKey _playerKey;

        private readonly Subject<AttackParameter> _onAttacked = new();
        public Observable<AttackParameter> OnAttacked => _onAttacked;

        public PlayerAttackPassiveUseCase(PlayerParameters playerParameters, PlayerKey playerKey)
        {
            _playerParameters = playerParameters;
            _playerKey = playerKey;
        }

        public void AttackCall(AttackParameter attackParameter)
        {
            if (attackParameter.OwnerKey == _playerKey)
                return;
            if (!HitCheck())
                return;

            //Domain
            _playerParameters.CurrentLife -= (int)attackParameter.AttackPower;
            _onAttacked.OnNext(attackParameter);
        }


        //無敵チェックとか
        private bool HitCheck()
        {
            return true;
        }
    }
}