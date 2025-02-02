using R3;
using SpellProject.Battle.Domain.UseCase;
using Takenokohal.Utility;
using UnityEngine;

namespace SpellProject.Battle.View
{
    public class PlayerAttackPassiveAnimationView : MonoBehaviour
    {
        private PlayerAttackPassiveUseCase _playerAttackPassiveUseCase;

        private Animator _animator;

        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        public void Construct(PlayerAttackPassiveUseCase playerAttackPassiveUseCase)
        {
            _playerAttackPassiveUseCase = playerAttackPassiveUseCase;

            _playerAttackPassiveUseCase.OnAttacked.Subscribe(_ => OnAttackedAnimation());
        }

        public void OnAttackedAnimation()
        {
            _animator.transform.localPosition = Vector2Extension.AngleToVector(Random.Range(0, 360f));
        }
    }
}