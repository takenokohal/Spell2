using System;
using System.Threading;
using SpellProject.Battle.Domain.BaseRules.MagicCircles;
using SpellProject.Battle.Domain.BaseRules.Spell;
using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces.Factory;
using SpellProject.Battle.Expansion.Spells;
using SpellProject.Data.Database;
using UnityEngine;
using VContainer;

namespace SpellProject.Battle.God.Factory
{
    //Spellは生成した側だけが処理実行
    public class SpellFactory : ISpellFactory, IDisposable
    {
        [Inject] private readonly IBattleObjectFactory _battleObjectFactory;
        [Inject] private readonly ISpellAdditionalDatabase _spellAdditionalDatabase;
        [Inject] private readonly AllPlayerManager _allPlayerManager;
        [Inject] private readonly IMagicCircleFactory _magicCircleFactory;

        private readonly CancellationTokenSource _cancellationTokenSource = new();

        public ISpellSequence Create(PlayerKey playerKey, string spellKey)
        {
            var instance = CreateInstance(spellKey);
            if (instance == null)
            {
                Debug.LogError("SpellKey not found");
                return null;
            }

            instance.Construct(
                _battleObjectFactory,
                _spellAdditionalDatabase,
                playerKey,
                _allPlayerManager,
                _magicCircleFactory,
                _cancellationTokenSource.Token);
            return instance;
        }

        private SpellBase CreateInstance(string spellKey)
        {
            //共通クラスを渡す場合がある
            return spellKey switch
            {
                "FireShoot" => new FireBall(),
                "FireCracker" => new FireCracker(),
                _ => null
            };
        }

        public void Dispose()
        {
            _cancellationTokenSource?.Dispose();
        }
    }
}