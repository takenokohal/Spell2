using Battle.Detail.Input;
using Battle.Domain.Interfaces;
using Battle.Domain.UseCase;
using Battle.Network;
using UnityEngine;

namespace Battle.Controller
{
    public class PlayerInputController : MonoBehaviour
    {
        private BattleInputWrapper _battleInputWrapper;
        private PlayerSpellUseCase _playerSpellUseCase;
        private PlayerMoveUseCase _playerMoveUseCase;

        private IBattleModeManager _battleModeManager;

        private bool _isInitialized;

        public class ConstructParameter
        {
            public BattleInputWrapper BattleInputWrapper { get; }
            public PlayerSpellUseCase PlayerSpellUseCase { get; }


            public PlayerMoveUseCase PlayerMoveUseCase { get; }

            public IBattleModeManager BattleModeManager { get; }

            public ConstructParameter(BattleInputWrapper battleInputWrapper, PlayerSpellUseCase playerSpellUseCase,
                PlayerMoveUseCase playerMoveUseCase, IBattleModeManager battleModeManager)
            {
                BattleInputWrapper = battleInputWrapper;
                PlayerSpellUseCase = playerSpellUseCase;
                PlayerMoveUseCase = playerMoveUseCase;
                BattleModeManager = battleModeManager;
            }
        }

        public void Construct(ConstructParameter constructParameter)
        {
            _battleInputWrapper = constructParameter.BattleInputWrapper;
            _playerSpellUseCase = constructParameter.PlayerSpellUseCase;
            _playerMoveUseCase = constructParameter.PlayerMoveUseCase;
            _battleModeManager = constructParameter.BattleModeManager;

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
            if (_battleInputWrapper.WasPressedThisFrame(BattleInputButton.Chant0))
            {
                if (_battleModeManager.BattleMode == BattleMode.Online)
                {
                    _playerSpellUseCase.NetworkChant();
                }
                else
                {
                    _playerSpellUseCase.Chant();
                }
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