using System;
using SpellProject.Battle.Detail.Input;
using SpellProject.Battle.Domain.UseCase;
using UnityEngine;

namespace SpellProject.Battle.Controller
{
    public class PlayerInputController : MonoBehaviour
    {
        private BattleInputWrapper _battleInputWrapper;
        private PlayerSpellUseCase _playerSpellUseCase;
        private PlayerMoveUseCase _playerMoveUseCase;
        
        private bool _isInitialized;

        public class ConstructParameter
        {
            public BattleInputWrapper BattleInputWrapper { get; }
            public PlayerSpellUseCase PlayerSpellUseCase { get; }


            public PlayerMoveUseCase PlayerMoveUseCase { get; }


            public ConstructParameter(BattleInputWrapper battleInputWrapper, PlayerSpellUseCase playerSpellUseCase,
                PlayerMoveUseCase playerMoveUseCase)
            {
                BattleInputWrapper = battleInputWrapper;
                PlayerSpellUseCase = playerSpellUseCase;
                PlayerMoveUseCase = playerMoveUseCase;
            }
        }

        public void Construct(ConstructParameter constructParameter)
        {
            _battleInputWrapper = constructParameter.BattleInputWrapper;
            _playerSpellUseCase = constructParameter.PlayerSpellUseCase;
            _playerMoveUseCase = constructParameter.PlayerMoveUseCase;

            _isInitialized = true;
        }

        private void Update()
        {
            if (!_isInitialized)
                return;

            TryChant();
        }

        private void TryChant()
        {
            const int handMax = 4;
            for (int i = 0; i < handMax; i++)
            {
                var button = Enum.Parse<BattleInputButton>("Chant" + i);
                if (!_battleInputWrapper.WasPressedThisFrame(button))
                    continue;

                _playerSpellUseCase.Chant(i);
            }
        }

        private void FixedUpdate()
        {
            if (!_isInitialized)
                return;
            TryMove();
        }

        private void TryMove()
        {
            _playerMoveUseCase.Move(_battleInputWrapper.GetDirection());
        }
    }
}