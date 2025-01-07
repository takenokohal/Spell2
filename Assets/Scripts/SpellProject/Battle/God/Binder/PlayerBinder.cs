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
using SpellProject.Battle.Infrastructure;
using SpellProject.Battle.Network;
using SpellProject.Battle.View;
using SpellProject.Data.Database;
using UnityEngine;
using VContainer;

namespace SpellProject.Battle.God.Binder
{
    public class PlayerBinder : MonoBehaviour, IPlayerBinder
    {
        [Inject] private readonly AllPlayerManager _allPlayerManager;
        [Inject] private readonly ISpellFactory _spellFactory;
        [Inject] private readonly IPlayerConstData _playerConstData;
        [Inject] private readonly SpellDatabase _spellDatabase;

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

            //Deck
            var deck = new PlayerDeck();
            var hand = new PlayerHand();
            var initializer = new PlayerSpellInitializer(new TestPlayerDeckLoader(), deck, hand);
            initializer.InitializeAll();

            UniTask.Void(async () =>
            {
                await _battleModeManager.WaitUntilInitialize(destroyCancellationToken);
                switch (_battleModeManager.BattleMode)
                {
                    case BattleMode.Online:
                        ManageNetworkMode(hasAuthority, characterBodyView, playerKey, playerBody, deck, hand);
                        break;
                    case BattleMode.OfflineVersus:
                        ManageOfflineVersus(playerKey, characterBodyView, playerBody, deck, hand);
                        break;
                    case BattleMode.OfflineSingle:
                        break;
                    case BattleMode.Training:
                        ManageTraining(playerKey, characterBodyView, playerBody, deck, hand);
                        break;
                    case BattleMode.Tutorial:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
        }

        private void ManageNetworkMode(
            bool hasAuthority,
            Component characterBodyView,
            PlayerKey playerKey,
            PlayerBody playerBody,
            PlayerDeck playerDeck,
            PlayerHand playerHand)
        {
            //Network
            var invertedRpc = characterBodyView.GetComponent<NetworkInvertedRpc>();
            invertedRpc.Construct(_spellFactory, playerKey, _spellDatabase);

            //Input is LocalOnly
            if (!hasAuthority)
                return;

            //UseCase
            var spellUseCase = new PlayerSpellUseCase(_spellFactory, playerKey, invertedRpc, playerDeck, playerHand);
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

        private void ManageTraining(
            PlayerKey playerKey,
            CharacterBodyView characterBodyView,
            PlayerBody playerBody,
            PlayerDeck playerDeck,
            PlayerHand playerHand)
        {
            //2Pは操作不可に
            if (playerKey.ID != 0)
                return;

            //後で依存逆転したいかも
            //Network
            var invertedRpc = characterBodyView.GetComponent<NetworkInvertedRpc>();
            invertedRpc.Construct(_spellFactory, playerKey, _spellDatabase);

            var spellUseCase = new PlayerSpellUseCase(_spellFactory, playerKey, invertedRpc, playerDeck, playerHand);
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

        private void ManageOfflineVersus(
            PlayerKey playerKey,
            CharacterBodyView characterBodyView,
            PlayerBody playerBody,
            PlayerDeck playerDeck,
            PlayerHand playerHand)
        {
            //後で依存逆転したいかも
            //Network
            var invertedRpc = characterBodyView.GetComponent<NetworkInvertedRpc>();
            invertedRpc.Construct(_spellFactory, playerKey, _spellDatabase);

            var spellUseCase = new PlayerSpellUseCase(_spellFactory, playerKey, invertedRpc, playerDeck, playerHand);
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