using Cysharp.Threading.Tasks;

namespace Battle.Domain.BaseRules.Spell
{
    public interface ISpellSequence
    {
        public UniTask Sequence();
    }
}