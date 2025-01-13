using SpellProject.Battle.Domain.Core.Attack;
using SpellProject.Battle.Domain.Interfaces.Attack;
using SpellProject.Battle.Domain.UseCase;
using UnityEngine;

namespace SpellProject.Battle.Controller
{
    public class PlayerAttackPassiveController : MonoBehaviour, IAttackPassiveController
    {
        private PlayerAttackPassiveUseCase _playerAttackPassiveUseCase;

        private bool _isInitialized;

        public void Construct(PlayerAttackPassiveUseCase playerAttackPassiveUseCase)
        {
            _playerAttackPassiveUseCase = playerAttackPassiveUseCase;
            _isInitialized = true;
        }


        void IAttackPassiveController.OnAttacked(AttackParameter attackParameter)
        {
            if(!_isInitialized)
                return;
            _playerAttackPassiveUseCase.AttackCall(attackParameter);
        }
    }
}