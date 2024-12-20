using Battle.God.Factory;
using Battle.Model.BattleObject;
using Battle.Model.Player;
using Cysharp.Threading.Tasks;
using Data;
using Data.Database;
using Fusion;

namespace Battle.Model.Spell
{
    public abstract class SpellBase : ISpellSequence
    {
        protected BattleObjectFactory BattleObjectFactory { get; private set; }
        private SpellAdditionalDatabase _spellAdditionalDatabase;
        protected PlayerFacade Owner { get; private set; }
        
        protected T GetAdditionalData<T>() where T : ISpellAdditionalData
        {
            return _spellAdditionalDatabase.GetData<T>();
        }

        public class ConstructParameters
        {
            public BattleObjectFactory BattleObjectFactory { get; }
            public SpellAdditionalDatabase SpellAdditionalDatabase { get; }
            
            public PlayerFacade Owner { get; }

            public ConstructParameters(BattleObjectFactory battleObjectFactory,
                SpellAdditionalDatabase spellAdditionalDatabase, PlayerFacade owner)
            {
                BattleObjectFactory = battleObjectFactory;
                SpellAdditionalDatabase = spellAdditionalDatabase;
                Owner = owner;
            }
        }


        public void Construct(ConstructParameters constructParameters)
        {
            BattleObjectFactory = constructParameters.BattleObjectFactory;
            _spellAdditionalDatabase = constructParameters.SpellAdditionalDatabase;
            Owner = constructParameters.Owner;
        }

        public abstract UniTask Sequence();
    }
}