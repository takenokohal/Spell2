using Cysharp.Threading.Tasks;
using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces.Factory;

namespace SpellProject.Battle.Domain.BaseRules.Spell
{
    public abstract class SpellBase : ISpellSequence
    {
        protected IBattleObjectFactory BattleObjectFactory { get; private set; }
        private ISpellAdditionalDatabase _spellAdditionalDatabase;
        protected PlayerFacade Owner { get; private set; }
        
        protected T GetAdditionalData<T>() where T : ISpellAdditionalData
        {
            return _spellAdditionalDatabase.GetData<T>();
        }

        public class ConstructParameters
        {
            public IBattleObjectFactory BattleObjectFactory { get; }
            public ISpellAdditionalDatabase SpellAdditionalDatabase { get; }
            
            public PlayerFacade Owner { get; }

            public ConstructParameters(IBattleObjectFactory battleObjectFactory,
                ISpellAdditionalDatabase spellAdditionalDatabase, PlayerFacade owner)
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