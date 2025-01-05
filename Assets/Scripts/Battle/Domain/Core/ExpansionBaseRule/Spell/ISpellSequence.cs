using Cysharp.Threading.Tasks;

namespace Battle.Domain.Core.ExpansionBaseRule.Spell
{
    public interface ISpellSequence
    {
        public UniTask Sequence();
    }
}