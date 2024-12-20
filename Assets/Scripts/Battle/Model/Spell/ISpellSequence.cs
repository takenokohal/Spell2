using Cysharp.Threading.Tasks;

namespace Battle.Model.Spell
{
    public interface ISpellSequence
    {
        public UniTask Sequence();
    }
}