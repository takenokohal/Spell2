using Fusion;
using R3;
using SpellProject.Battle.Domain.UseCase;
using SpellProject.Battle.View;

namespace SpellProject.Battle.Network
{
    public class NetworkedPlayerAnimationCall : NetworkBehaviour
    {
        private PlayerAttackPassiveAnimationView _animationView;
        private PlayerAttackPassiveUseCase _playerAttackPassiveUseCase;

        public void Construct(PlayerAttackPassiveAnimationView animationView,
            PlayerAttackPassiveUseCase playerAttackPassiveUseCase)
        {
            _animationView = animationView;
            _playerAttackPassiveUseCase = playerAttackPassiveUseCase;

            _playerAttackPassiveUseCase.OnAttacked.Subscribe(_ => OnAttackedRpc()).AddTo(this);
        }


        [Rpc(RpcSources.StateAuthority, RpcTargets.Proxies, InvokeLocal = false)]
        public void OnAttackedRpc()
        {
            _animationView.OnAttackedAnimation();
        }
    }
}