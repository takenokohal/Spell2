using Cysharp.Threading.Tasks;
using SpellProject.Battle.Domain.BaseRules.MagicCircles;
using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces.Factory;
using UnityEngine;

namespace SpellProject.Battle.Domain.BaseRules.Spell
{
    public abstract class SpellBase : ISpellSequence
    {
        protected IBattleObjectFactory BattleObjectFactory { get; private set; }
        private ISpellAdditionalDatabase _spellAdditionalDatabase;
        
        protected PlayerKey OwnerKey { get; private set; }
        protected PlayerFacade OwnerFacade => AllPlayerManager.GetPlayer(OwnerKey);
        protected PlayerFacade EnemyFacade => AllPlayerManager.GetEnemy(OwnerKey);
        protected AllPlayerManager AllPlayerManager { get; private set; }
        protected IMagicCircleFactory MagicCircleFactory { get; private set;}

        protected T GetAdditionalData<T>() where T : ISpellAdditionalData
        {
            return _spellAdditionalDatabase.GetData<T>();
        }


        public void Construct(
            IBattleObjectFactory battleObjectFactory,
            ISpellAdditionalDatabase spellAdditionalDatabase,
            PlayerKey ownerKey,
            AllPlayerManager allPlayerManager,
            IMagicCircleFactory magicCircleFactory)
        {
            BattleObjectFactory = battleObjectFactory;
            _spellAdditionalDatabase = spellAdditionalDatabase;
            OwnerKey = ownerKey;
            AllPlayerManager = allPlayerManager;
            MagicCircleFactory = magicCircleFactory;
        }

        public abstract UniTask Sequence();

        public Vector2 GetDirectionOwnerToPlayer()
        {
            return EnemyFacade.GetDirectionToPlayer(OwnerFacade.PlayerBody.Position);
        }

    }
}