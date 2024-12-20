using Battle.Model.Player;
using UnityEngine;

namespace Battle.Input
{
    public class PlayerInputController : MonoBehaviour
    {
        private BattleInputWrapper _battleInputWrapper;
        private PlayerSpellController _playerSpellController;
        private PlayerMoveController _playerMoveController;

        private bool _isInitialized;

        public class ConstructParameter
        {
            public BattleInputWrapper BattleInputWrapper { get; }
            public PlayerSpellController PlayerSpellController { get; }


            public PlayerMoveController PlayerMoveController { get; }

            public ConstructParameter(
                BattleInputWrapper battleInputWrapper,
                PlayerSpellController playerSpellController,
                PlayerMoveController playerMoveController)
            {
                BattleInputWrapper = battleInputWrapper;
                PlayerSpellController = playerSpellController;
                PlayerMoveController = playerMoveController;
            }
        }

        public void Construct(ConstructParameter constructParameter)
        {
            _battleInputWrapper = constructParameter.BattleInputWrapper;
            _playerSpellController = constructParameter.PlayerSpellController;
            _playerMoveController = constructParameter.PlayerMoveController;

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
                _playerSpellController.Chant();
        }

        private void FixedUpdate()
        {
            if (!_isInitialized)
                return;
            TryMove();
        }

        private void TryMove()
        {
            _playerMoveController.Move(_battleInputWrapper.GetDirection());
        }
    }
}