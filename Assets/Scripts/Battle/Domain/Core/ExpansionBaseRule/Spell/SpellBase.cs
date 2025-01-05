using Battle.Domain.Core.Player;
using Battle.Domain.Interfaces.Factory;
using Cysharp.Threading.Tasks;
using Data;
using Data.Database;

namespace Battle.Domain.Core.ExpansionBaseRule.Spell
{
    public abstract class SpellBase : ISpellSequence
    {
        protected IBattleObjectFactory BattleObjectFactory { get; private set; }
        private SpellAdditionalDatabase _spellAdditionalDatabase;
        protected PlayerFacade Owner { get; private set; }
        
        protected T GetAdditionalData<T>() where T : ISpellAdditionalData
        {
            return _spellAdditionalDatabase.GetData<T>();
        }

        public class ConstructParameters
        {
            public IBattleObjectFactory BattleObjectFactory { get; }
            public SpellAdditionalDatabase SpellAdditionalDatabase { get; }
            
            public PlayerFacade Owner { get; }

            public ConstructParameters(IBattleObjectFactory battleObjectFactory,
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