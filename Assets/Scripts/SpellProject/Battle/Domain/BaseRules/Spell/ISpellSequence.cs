using Cysharp.Threading.Tasks;

namespace SpellProject.Battle.Domain.BaseRules.Spell
{
    public interface ISpellSequence
    {
        public UniTask Sequence();
    }
}