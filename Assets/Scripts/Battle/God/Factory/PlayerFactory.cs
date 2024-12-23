using Battle.Input;
using Battle.Model.Attack;
using Battle.Model.Player;
using Battle.Network;
using Battle.Presenter;
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

        private int _index;

        public void Create()
        {
            _networkRunner.Spawn(playerSpawnCallPrefab);
        }


        private void ConstructPlayer(PlayerSpawnCall playerSpawnCall, bool hasAuthority)
        {
            var playerKey = new PlayerKey(_index);
            _index++;

            var playerView = playerSpawnCall.PlayerView;

            var playerBody = new PlayerBody(playerView);


            //Attack
            var attackHitController = new PlayerAttackHitController(playerView, playerKey);
            var attackHitPresenter = playerView.GetComponent<PlayerAttackHitPresenter>();
            attackHitPresenter.Construct(attackHitController);

            //Facade
            var playerFacade = new PlayerFacade(playerBody, playerKey);
            _allPlayerManager.Register(playerKey, playerFacade);


            //Network
            var invertedRpc = playerView.GetComponent<NetworkInvertedRpc>();
            invertedRpc.Construct(_spellFactory, playerKey);
            
            
            //Input is LocalOnly
            if (!hasAuthority)
                return;

            //Input
            var spellController = new PlayerSpellController(_spellFactory, playerKey, invertedRpc);
            var moveController = new PlayerMoveController(playerBody, _playerConstData);

            var input = playerView.GetComponent<PlayerInputPresenter>();
            input.Construct(
                new PlayerInputPresenter.ConstructParameter(
                    _battleInputWrapper,
                    spellController,
                    moveController
                ));
        }

        void PlayerSpawnCall.IPlayerSpawnCallback.OnSpawned(PlayerSpawnCall playerSpawnCall, bool hasAuthority)
        {
            ConstructPlayer(playerSpawnCall, hasAuthority);
        }
    }
}