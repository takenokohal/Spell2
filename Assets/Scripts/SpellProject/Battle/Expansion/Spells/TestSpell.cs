using Cysharp.Threading.Tasks;
using SpellProject.Battle.Domain.BaseRules.Spell;
using SpellProject.Data;

namespace SpellProject.Battle.Expansion.Spells
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