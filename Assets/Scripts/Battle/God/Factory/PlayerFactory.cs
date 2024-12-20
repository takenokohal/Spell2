using Battle.Input;
using Battle.Model.Player;
using Battle.Network;
using Data.Database;
using Fusion;
using UnityEngine;
using VContainer;

namespace Battle.God.Factory
{
    public class PlayerFactory : MonoBehaviour, PlayerSpawnCall.IPlayerSpawnCallback
    {
        [SerializeField] private PlayerSpawnCall playerSpawnCallPrefab;

        [Inject] private readonly AllPlayerManager _allPlayerManager;
        [Inject] private readonly BattleInputWrapper _battleInputWrapper;
        [Inject] private readonly SpellFactory _spellFactory;
        [Inject] private readonly NetworkRunner _networkRunner;
        
        [Inject] private readonly PlayerConstData _playerConstData;

        public void Create()
        {
            _networkRunner.Spawn(playerSpawnCallPrefab);
        }

        void PlayerSpawnCall.IPlayerSpawnCallback.OnSpawned(PlayerSpawnCall playerSpawnCall)
        {
            ConstructPlayer(playerSpawnCall);
        }

        private void ConstructPlayer(PlayerSpawnCall playerSpawnCall)
        {
            var playerKey = new PlayerKey();

            var playerView = playerSpawnCall.PlayerView;

            var playerBody = new PlayerBody(playerView);
            var playerFacade = new PlayerFacade(playerBody, playerKey);

            var input = playerView.GetComponent<PlayerInputController>();
            input.Construct(
                new PlayerInputController.ConstructParameter(
                    _battleInputWrapper,
                    new PlayerSpellController(_spellFactory, playerKey),
                    new PlayerMoveController(playerBody, _playerConstData)));

            _allPlayerManager.Register(playerKey, playerFacade);
        }
    }
}