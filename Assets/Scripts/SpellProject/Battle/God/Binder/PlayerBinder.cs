using System;
using Cysharp.Threading.Tasks;
using SpellProject.Battle.Controller;
using SpellProject.Battle.Detail.Input;
using SpellProject.Battle.Domain.Core;
using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces;
using SpellProject.Battle.Domain.Interfaces.Factory;
using SpellProject.Battle.Domain.Interfaces.Player;
using SpellProject.Battle.Domain.UseCase;
using SpellProject.Battle.Network;
using SpellProject.Battle.View;
using UnityEngine;
using VContainer;

namespace SpellProject.Battle.God.Binder
{
    public class PlayerBinder : MonoBehaviour, IPlayerBinder
    {
        [Inject] private readonly AllPlayerManager _allPlayerManager;
        [Inject] private readonly ISpellFactory _spellFactory;
        [Inject] private readonly IPlayerConstData _playerConstData;

        [Inject] private readonly IBattleModeManager _battleModeManager;

        private int _index;

        void IPlayerBinder.Bind(PlayerSpawnCall playerSpawnCall, bool hasAuthority)
        {
            var playerKey = new PlayerKey(_index);
            _index++;

            var characterBodyView = playerSpawnCall.GetComponent<CharacterBodyView>();

            var playerBody = new PlayerBody(characterBodyView);


            //Facade
            var playerFacade = new PlayerFacade(playerBody, playerKey);
            _allPlayerManager.Register(playerKey, playerFacade);


            UniTask.Void(async () =>
            {
                await _battleModeManager.WaitUntilInitialize(destroyCancellationToken);
                switch (_battleModeManager.BattleMode)
                {
                    case BattleMode.Online:
                        ManageNetworkMode(hasAuthority, characterBodyView, playerKey, playerBody);
                        break;
                    case BattleMode.OfflineVersus:
                        break;
                    case BattleMode.OfflineSingle:
                        break;
                    case BattleMode.Training:
                        ManageTraining(playerKey, characterBodyView, playerBody);
                        break;
                    case BattleMode.Tutorial:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
        }

        private void ManageNetworkMode(bool hasAuthority, Component characterBodyView, PlayerKey playerKey,
            PlayerBody playerBody)
        {
            //Network
            var invertedRpc = characterBodyView.GetComponent<NetworkInvertedRpc>();
            invertedRpc.Construct(_spellFactory, playerKey);

            //Input is LocalOnly
            if (!hasAuthority)
                return;

            //UseCase
            var spellUseCase = new PlayerSpellUseCase(_spellFactory, playerKey, invertedRpc);
            var moveUseCase = new PlayerMoveUseCase(playerBody, _playerConstData);

            var input = characterBodyView.GetComponent<PlayerInputController>();
            input.Construct(
                new PlayerInputController.ConstructParameter(
                    characterBodyView.GetComponent<BattleInputWrapper>(),
                    spellUseCase,
                    moveUseCase,
                    _battleModeManager
                ));
        }

        private void ManageTraining(PlayerKey playerKey, CharacterBodyView characterBodyView, PlayerBody playerBody)
        {
            //後で依存逆転したいかも
            //Network
            var invertedRpc = characterBodyView.GetComponent<NetworkInvertedRpc>();
            invertedRpc.Construct(_spellFactory, playerKey);

            var spellUseCase = new PlayerSpellUseCase(_spellFactory, playerKey, invertedRpc);
            var moveUseCase = new PlayerMoveUseCase(playerBody, _playerConstData);

            var input = characterBodyView.GetComponent<PlayerInputController>();
            input.Construct(
                new PlayerInputController.ConstructParameter(
                    characterBodyView.GetComponent<BattleInputWrapper>(),
                    spellUseCase,
                    moveUseCase,
                    _battleModeManager
                ));
        }
    }
}