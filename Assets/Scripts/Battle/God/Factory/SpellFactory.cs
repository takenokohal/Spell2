using Battle.Model.Player;
using Battle.Model.Spell;
using Battle.Model.Spell.Variable;
using Data.Database;
using UnityEngine;
using VContainer;

namespace Battle.God.Factory
{
    //Spellは生成した側だけが処理実行
    public class SpellFactory
    {
        [Inject] private readonly BattleObjectFactory _battleObjectFactory;
        [Inject] private readonly SpellAdditionalDatabase _spellAdditionalDatabase;
        [Inject] private readonly AllPlayerManager _allPlayerManager;

        public ISpellSequence Create(PlayerKey playerKey, string spellKey)
        {
            var instance = CreateInstance(spellKey);
            if (instance == null)
            {
                Debug.LogError("SpellKey not found");
                return null;
            }

            instance.Construct(new SpellBase.ConstructParameters(
                _battleObjectFactory,
                _spellAdditionalDatabase,
                _allPlayerManager.Players[playerKey]));
            return instance;
        }

        private SpellBase CreateInstance(string spellKey)
        {
            //共通クラスを渡す場合がある
            return spellKey switch
            {
                "TestSpell" => new TestSpell(),
                "FireBall"=> new FireBall(),
                _ => null
            };
        }
    }
}