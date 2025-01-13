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
using SpellProject.Battle.View.UI;
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

        [Inject] private readonly PlayerLifeViewManager _playerLifeViewManager;

        private int _index;

        void IPlayerBinder.Bind(PlayerSpawnCall playerSpawnCall, bool hasAuthority)
        {
            var playerKey = new PlayerKey(_index);
            _index++;

            //View
            var characterBodyView = playerSpawnCall.GetComponent<CharacterBodyController>();
            characterBodyView.Construct(playerKey);
            var playerBody = new PlayerBody(characterBodyView);

            var playerParameters = new PlayerParameters();
            playerParameters.Init(_playerConstData.PlayerMaxLife);

            //Facade
            var playerFacade = new PlayerFacade(playerBody, playerKey, playerParameters);
            _allPlayerManager.Register(playerKey, playerFacade);

            //Deck
            var deck = new PlayerDeck();
            var hand = new PlayerHand();
            var initializer = new PlayerSpellInitializer(new TestPlayerDeckLoader(), deck, hand);
            initializer.InitializeAll();

            //UI
            var view = _playerLifeViewManager.PlayerLifeUIViews[playerKey.ID];
            view.Construct(_playerConstData, playerParameters);


            UniTask.Void(async () =>
            {
                await _battleModeManager.WaitUntilInitialize(destroyCancellationToken);

                ManageInput(hasAuthority, playerKey, characterBodyView, playerBody, hand, deck);

                ManageAttack(hasAuthority, playerParameters, playerKey, characterBodyView);
            });
        }

        private void ManageInput(
            bool hasAuthority,
            PlayerKey playerKey,
            Component characterBodyView,
            PlayerBody playerBody,
            PlayerHand hand,
            PlayerDeck deck)
        {
            var battleMode = _battleModeManager.BattleMode;
            var inputAuthority = battleMode switch
            {
                BattleMode.Online => hasAuthority,
                BattleMode.OfflineVersus => true,
                BattleMode.OfflineSingle => true,
                BattleMode.Training => playerKey.ID == 0,
                BattleMode.Tutorial => playerKey.ID == 0,
                _ => throw new ArgumentOutOfRangeException()
            };



            PlayerSpellUseCase.ISpellChantCall chant;
            if (battleMode == BattleMode.Online)
            {
                var v = characterBodyView.GetComponent<NetworkPlayerChant>();
                v.Construct(_spellFactory, playerKey, _spellDatabase);
                chant = v;
            }
            else
            {
                chant = new OfflinePlayerSpellChant(_spellFactory, playerKey);
            }
            
            if (!inputAuthority)
                return;

            //UseCase
            var spellUseCase = new PlayerSpellUseCase(chant, hand, deck);
            var moveUseCase = new PlayerMoveUseCase(playerBody, _playerConstData);

            var input = characterBodyView.GetComponent<PlayerInputController>();
            input.Construct(
                new PlayerInputController.ConstructParameter(
                    characterBodyView.GetComponent<BattleInputWrapper>(),
                    spellUseCase,
                    moveUseCase));
        }

        private void ManageAttack(
            bool hasAuthority,
            PlayerParameters playerParameters,
            PlayerKey playerKey,
            Component characterBodyView)
        {
            if (_battleModeManager.BattleMode == BattleMode.Online && !hasAuthority)
                return;
            var attackPassiveUsecase = new PlayerAttackPassiveUseCase(playerParameters, playerKey);

            var attackPassiveController = characterBodyView.GetComponent<PlayerAttackPassiveController>();
            attackPassiveController.Construct(attackPassiveUsecase);
        }
    }
}