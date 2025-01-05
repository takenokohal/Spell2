using Battle.Domain.BaseRules.Spell;
using Cysharp.Threading.Tasks;
using Data;

namespace Battle.Expansion.Spells
{
    public class TestSpell : SpellBase
    {
        private class AdditionalData : ISpellAdditionalData
        {
            public string BulletKey;
        }

        public override UniTask Sequence()
        {
            return UniTask.CompletedTask;

        }
    }
}